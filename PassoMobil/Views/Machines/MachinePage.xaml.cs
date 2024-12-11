using PassoMobil.Models;
using PassoMobil.Services;
using Microsoft.AspNetCore.SignalR.Client;

namespace PassoMobil.Views.Machines;

public partial class MachinePage : ContentPage
{
	public MachinePage()
	{
		InitializeComponent();
   
        Task.Run(async () =>
        {
            await SetData();
        });
	}
   

  
    private async Task SetData()
    {
        try
        {
            var result = await ApiService.GetAsync<List<Cihaz>>("https://example.com/");
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                BindingContext = result;
                yukleniyor.IsRunning = false;
                yukleniyor.IsVisible = false;
            });
           
        }
        catch (Exception ex)
        {
            yukleniyor.IsRunning = false;
            yukleniyor.IsVisible = false;

        }
        finally
        {

        }
    }

}