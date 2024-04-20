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
            Song test1 = await testAPI.GetSong("Metallica", "Here comes revenge");
            Console.Write(test1);
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
                    Song song = JsonSerializer.Deserialize<Song>(response);
                    song.author = author;
                    song.title = title;
                    song.lyrics = song.lyrics.Substring(song.lyrics.IndexOf('\n') + 1, song.lyrics.Length - song.lyrics.IndexOf('\n') - 1);

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
