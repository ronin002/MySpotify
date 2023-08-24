using MySpotify.Mob.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MySpotify.Mob.Services
{
    public class APIServices
    {

        const string URL_MY_SPOTIFY_API_HOST = "https://localhost:7153/"; // "https://192.168.0.20:45457/";
        #region Constats

        public const string MUSICS_GET_ALL = "Music/GetAll";
        public const string MUSICS_GET_BY_ID = "Music/GetById";
        public const string MUSICS_GET_BY_NAME = "Music/GetByName";
        public const string MUSICS_GET_BY_SINGER = "Music/GetBySinger";
        public const string MUSICS_GET_BY_RHYTHM = "Music/GetByRhythm";
        #endregion

        private static HttpClient ApiClient { get; set; }
        
        private HttpResponseMessage ResponseMessage { get; set; }
        private string ResultRaw { get; set; }


        public APIServices()
        {
            //InitializeClient();
        }
        public async void GetMusicsALL()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL_MY_SPOTIFY_API_HOST + MUSICS_GET_ALL);

            var data = await response.Content.ReadAsStringAsync();
        }

        public static void InitializeClient()
        {

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(URL_MY_SPOTIFY_API_HOST );
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

        }

        public async Task<List<Music>> GetAllMusics()
        {
            List<Music> musics = new List<Music>();
            var result = await ToGetResponseURL(MUSICS_GET_ALL);

            return musics;
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        /*
        public string GetMusics()
        {

            HttpClient client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri(URL_MY_SPOTIFY_API_HOST);
            string urlParameters = MUSICS_GET_ALL;
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Music>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return urlParameters;
        }
        */
        public async Task<HttpResponseMessage> ToGetResponseURL(string URI)
        {
            var response = ApiClient.GetAsync(
                   URL_MY_SPOTIFY_API_HOST + URI).Result;

            ResponseMessage = response;

            var statusCode = response.StatusCode;
            ResultRaw = await response.Content.ReadAsStringAsync();
            if ((int)statusCode != 200) return null;

            return response;
        }


 
    }
}
