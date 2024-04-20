using System.Collections.Frozen;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace API_BD
{
    internal class Program
    {
        static async Task<Song> GetSong(string author, string title)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string URL = $"https://api.lyrics.ovh/v1/{author}/{title}";
                    string response = await httpClient.GetStringAsync(URL);
                    //string responseBody = await response.Content.ReadAsStringAsync();
                    Song song = JsonSerializer.Deserialize<Song>(response);
                    song.author = author;
                    song.title = title;
                    song.lyrics = song.lyrics.Substring(song.lyrics.IndexOf('\n') + 1, song.lyrics.Length - song.lyrics.IndexOf('\n')-1);

                    //Console.WriteLine("Response:");
                    //Console.WriteLine(responseBody);
                    //Console.WriteLine(song.ToString());
                    return song;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                

            }

            return null;
        }

        static void Main(string[] args)
        {
            Song test1 = GetSong("Metallica", "Here comes revenge").Wait();
        }
    }
}
