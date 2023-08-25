namespace MySpotify.Mob
{
    public static class MauiProgram
    {

        const string URL_MY_SPOTIFY_API_HOST = "http://10.0.0.2:5153/";
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