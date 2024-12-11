using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Machines;

public partial class MachineActiveList : ContentPage
{
    private int _id = 0;
    public MachineActiveList(int id = 0)
    {
        InitializeComponent();
        _id = id;
    }

    [Obsolete]
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        IsBusy = true;
        Device.StartTimer(TimeSpan.FromSeconds(2), () => { 
            Task.Run(async () =>
            {
                await SetData();
            });
            return false;
        });
      
    }
    private async Task SetData()
    {
        try
        {
            var response = await ApiService.GetAsync<List<Aktive>>("https://example.com/" + _id);
            await Application.Current.Dispatcher.DispatchAsync( () =>
            {
                BindingContext = response;
                yukleniyor.IsRunning = false;
                yukleniyor.IsVisible = false;
                IsBusy = false;
            });

        }
        catch (Exception ex)
        {
            yukleniyor.IsRunning = false;
            yukleniyor.IsVisible = false;
            IsBusy = false;
        }
        finally
        {

        }
    }
}