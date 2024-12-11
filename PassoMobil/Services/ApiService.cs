
namespace PassoMobil.Services
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json; // JSON veriyi serileştirmek ve seriden çıkarmak için

    public static class ApiService
    {
        private  readonly static HttpClient _httpClient= new HttpClient();


        public static async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Request failed: {ex.Message}");
            }
        }
        public static async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestBody)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    if (jsonResult=="True"||jsonResult=="true")
                    {
                        return JsonConvert.DeserializeObject<TResponse>("");
                    }
                    else
                    {
                     return JsonConvert.DeserializeObject<TResponse>(jsonResult);
                    }
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<TResponse>("");
            }
        }
       
    }

}
