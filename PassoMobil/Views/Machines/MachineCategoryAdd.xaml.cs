using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Machines;

public partial class MachineCategoryAdd : ContentPage
{
	private Gorev _gorev;
	public MachineCategoryAdd(Gorev gorev)
	{
		InitializeComponent();
		_gorev = gorev;
        takim.Text = gorev.IstenilenKategori;
    }
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        _gorev.Bulundu = false;
        _gorev.Ertele = false;
        _gorev.IstenilenKategori = String.IsNullOrEmpty(takim.Text) ? "" : takim.Text;
        await ApiService.PostAsync<Gorev,object >("https://example.com/", _gorev);
        await Navigation.PopAsync();
    }
  
}