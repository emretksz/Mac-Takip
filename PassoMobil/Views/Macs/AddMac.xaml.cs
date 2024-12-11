using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Macs;

public partial class AddMac : ContentPage
{
	public AddMac()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {

        var mac = new Mac()
        {
            Takim = takim.Text
        };
        var response = await ApiService.PostAsync<Mac,Mac>("https://example.com/", mac);
        await Navigation.PopAsync();
    }
}