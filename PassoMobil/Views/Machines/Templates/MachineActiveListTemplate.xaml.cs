using PassoMobil.Models;

namespace PassoMobil.Views.Machines.Templates;

public partial class MachineActiveListTemplate : ContentView
{
	public MachineActiveListTemplate()
	{
		InitializeComponent();
	}
    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        var context = BindingContext as Aktive;

        Takim.Text = "Takým: "+context.Takim;
        Kategori.Text = "Kategori: " + context.Kategori ;
        Adet.Text = "Adet: " + context.Adet ;
        Zaman.Text = context.BulunduguZaman.ToString();
    }
}