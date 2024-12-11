using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Machines;

public partial class MachinesTaskList : ContentPage
{

    private int _cihazId = 0;
	public MachinesTaskList(int cihazId=0)
	{
		InitializeComponent();
        _cihazId = cihazId;
       
        

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        yukleniyor.IsRunning = true;
        yukleniyor.IsVisible = true;
        Task.Run(async () =>
        {
            await SetData();
        });
    }
    private async Task SetData()
    {
        try
        {
            var response = await ApiService.GetAsync<List<Gorev>>("https://example.com/" + _cihazId);
            if (response!=null && response.Count>0)
            {
                response = response.OrderByDescending(a => a.Bulundu == false).ToList();
            }
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                BindingContext = response;
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