using Music.Models.froogh_asgari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Music.HttpService
{
    public class MusicReport
    {
        private readonly HttpClient client;
        private const string BaseAdress = "https://www.theaudiodb.com";
        public List<User> Users = new List<User>();
        public MusicReport(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAdress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public MVideo GetMusicVideo(string ArtistId)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/mvid.php?i={ArtistId}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<MVideo>(stringContent);



            return new MVideo() { mvids = result.mvids.ToList() };

        }


        public Tracks GetTrackInf(string TrackId)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/track.php?h={TrackId}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Tracks>(stringContent);



            return result;

        }

        public Tracks GetFav(int Id)
        {
            foreach(var item in users)



            return result;

        }
    }
}
