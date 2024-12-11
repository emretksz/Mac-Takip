using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Machines.Templates;

public partial class TaskTemplate : ContentView
{
	public TaskTemplate()
	{
		InitializeComponent();
	}

    private Gorev _gorev;
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        var context = BindingContext as Gorev;
        _gorev = context;
        Takim.Text = "Takým: " + context.Mac;
        Kategori.Text = "Aranan Kategori: " + (String.IsNullOrEmpty(context.IstenilenKategori)?"Özel .... Yok": context.IstenilenKategori);
        Zaman.Text = "... Durumu: " + (context.Bulundu ? "....": (context.Ertele?"xxx":"...."));
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MachineCategoryAdd(_gorev));
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        _gorev.Bulundu = false;
        _gorev.Ertele = false;
        await ApiService.PostAsync<Gorev, object>("https://example.com/", _gorev);
       await App.Current.MainPage.DisplayAlert("Uyarý","xxxxxxxxxxxx","Tamam");
    }
}