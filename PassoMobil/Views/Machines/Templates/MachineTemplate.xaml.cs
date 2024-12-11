namespace PassoMobil.Views.Machines.Templates;

public partial class MachineTemplate : ContentView
{
	public MachineTemplate()
	{
		InitializeComponent();
	}
    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new MachinesTaskList(Convert.ToInt32(e.Parameter)));
        }
        catch (Exception ex)
        {
            // Hata durumunda kullanýcýya bilgi ver
            await Application.Current.MainPage.DisplayAlert("Hata", $"Bir hata oluþtu: {ex.Message}", "Tamam");
        }
        finally
        {
            // Yükleme iþlemi tamamlandýktan sonra yükleme göstergesini gizle
            yukle.IsVisible = false;
            yukle.IsRunning = false;
        }
    }

}