using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Macs.Templates;

public partial class MacTemplate : ContentView
{
	public MacTemplate()
	{
		InitializeComponent();
	}
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Hata", $"Bir hata oluþtu: {ex.Message}", "Tamam");
        }
        finally
        {
            yukle.IsVisible = false;
            yukle.IsRunning = false;
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var findSender = (ImageButton)sender;
        var mac = findSender.CommandParameter;
        try
        {

            await ApiService.PostAsync<Mac, bool>("https://example.com/", new Mac() { Takim = mac.ToString() });
            await Application.Current.MainPage.DisplayAlert("Dikkat", "xxxxxxxxxxxxxxxxxxx", "Tamam");
        }
        catch (Exception)
        {

        }


    }
}