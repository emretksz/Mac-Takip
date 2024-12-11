using Microsoft.AspNetCore.SignalR.Client;
using PassoMobil.Models;
using PassoMobil.Services;

namespace PassoMobil.Views.Macs;

public partial class MacPage : ContentPage
{
    private HubConnection _hubConnection;
    public MacPage()
    {
        InitializeComponent();
        Task.Run(async () =>
        {
            await InitializeSignalR();
        });

    }


    private async Task InitializeSignalR()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl("https://example.com/notificationHub") // Doðru URL
            .WithAutomaticReconnect() // Otomatik yeniden baðlanma
            .Build();

        _hubConnection.On<string, string>("ReceiveMessage", (title, message) =>
        {
            ShowLocalNotification(title, message);
        });

        try
        {
            await _hubConnection.StartAsync();
            Console.WriteLine("SignalR baðlantýsý baþarýlý.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SignalR baðlantý hatasý: {ex.Message}");
        }
    }

    private void ShowLocalNotification(string title, string message)
    {
#if ANDROID
        var androidNotificationService = new PassoMobil.Platforms.Android.AndroidNotificationService();
        androidNotificationService.ShowLocalNotification(title, message);
#elif IOS
        var iOSNotificationService = new PassoMobil.Platforms.iOS.iOSNotificationService();
        iOSNotificationService.ShowLocalNotification(title, message);
#endif
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Task.Run(async () =>
        {
         
            await SetData();
        });
    }
    private async Task SetData()
    {
        try
        {

            var response = await ApiService.GetAsync<List<Mac>>("https://example.com/");
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

    private async void ekle_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMac(), true);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {

    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }
}