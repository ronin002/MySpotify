using MySpotify.Mob.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace MySpotify.Mob.Services
{
    public class APIServices
    {

        const string URL_MY_SPOTIFY_API_HOST = "http://10.0.2.2:5153/"; // "https://192.168.0.20:45457/";
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
        public async  Task<List<Music>> GetMusicsALL()
        {
            List<Music> musics = new List<Music>();
            var httpClient = new HttpClient();
            //Console.WriteLine(URL_MY_SPOTIFY_API_HOST + MUSICS_GET_ALL);
            var response = await httpClient.GetAsync(URL_MY_SPOTIFY_API_HOST + MUSICS_GET_ALL);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                
                if (!string.IsNullOrEmpty(data))
                {
                    musics = JsonConvert.DeserializeObject<List<Music>>(data);
                }
               
            }


            //Console.WriteLine(data);
            return musics;
        }




 
    }
}
