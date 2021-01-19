using Music.Controllers;
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
        public Tracks SearchTrack(Person person)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/searchtrack.php?s={person.ArtistName}&t={person.SingleName}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Tracks>(stringContent);
       
            return new Tracks() { track = result.track.ToList() };

        }
        public Mode2 GetAlbumInfo(string Artistname)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/searchalbum.php?s={Artistname}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Mode2>(stringContent);

            return result;

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
        public Discography GetAlbum(string Artistname)
        {
            var httpResponse = client.GetAsync($"api/v1/json/1/discography.php?s=coldplay={Artistname}").Result;
            httpResponse.EnsureSuccessStatusCode();
            if (!httpResponse.IsSuccessStatusCode)
            {
                return null;
            }


            HttpContent content = httpResponse.Content;
            string stringContent = content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Discography>(stringContent);

            return new Discography() { album = result.album.ToList() };

        }


        public List<Tracks> GetFav(int Id)
        {

            var FavTracks = new List<Tracks>();
            foreach(var item in UserController.repository.users.FirstOrDefault(x => x.Id == Id).FavoritesTI)
            {
                var httpResponse = client.GetAsync($"api/v1/json/1/track.php?h={item}").Result;
                httpResponse.EnsureSuccessStatusCode();
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }


                HttpContent content = httpResponse.Content;
                string stringContent = content.ReadAsStringAsync().Result;

                var result = JsonSerializer.Deserialize<Tracks>(stringContent);
                FavTracks.Add(result);

            }
 
            return FavTracks;


            
        }
    }
}
