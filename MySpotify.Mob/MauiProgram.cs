namespace MySpotify.Mob
{
    public static class MauiProgram
    {

        const string URL_MY_SPOTIFY_API_HOST = "https://192.168.0.20:45457/";
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //builder.Services.AddHttpClient("apiMySpotify",httpClient => httpClient.BaseAddress = new Uri(URL_MY_SPOTIFY_API_HOST));

            return builder.Build();
        }
    }
}