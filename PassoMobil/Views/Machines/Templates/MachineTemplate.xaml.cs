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
            // Hata durumunda kullan�c�ya bilgi ver
            await Application.Current.MainPage.DisplayAlert("Hata", $"Bir hata olu�tu: {ex.Message}", "Tamam");
        }
        finally
        {
            // Y�kleme i�lemi tamamland�ktan sonra y�kleme g�stergesini gizle
            yukle.IsVisible = false;
            yukle.IsRunning = false;
        }
    }

}