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

        public MusicReport(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(BaseAdress);
            this.client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public Mode1 SearchTrack(string ArtistName,string TrackName)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/searchtrack.php?s={ArtistName}&t={TrackName}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Mode1>(stringContent);
            // mage nabayad artistname o track name begire??
            return new Mode1() { track = result.track.ToList() };

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
    }
}
