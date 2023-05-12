using Plugin.Firebase.CloudMessaging;

namespace MauiFirebaseDemo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        Console.WriteLine($"FCM token: {token}");
    }
}

