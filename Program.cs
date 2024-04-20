using System.Collections.Frozen;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace API_BD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            API testAPI = new API();
            //Song test1 = await testAPI.GetSong("Metallica", "Fuel");
            SongBase db = new SongBase();
            Song test = db.songs.Where(s => s.title == "Fuel").First();
            //db.songs.Add(test1);
            //db.SaveChanges();
            Console.WriteLine(test);
        }
    }

    public class API
    {
        public async Task<Song> GetSong(string author, string title)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string URL = $"https://api.lyrics.ovh/v1/{author}/{title}";
                    string response = await httpClient.GetStringAsync(URL);
                    Lyrics lyrics = JsonSerializer.Deserialize<Lyrics>(response);
                    
                    Song song = new Song(author, title, lyrics.lyrics);
                    return song;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return null;
        }
    }
}
