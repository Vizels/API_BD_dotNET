using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BD
{
    public class Song
    {

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string lyrics { get; set; }
        public Song(string author, string title, string lyrics)
        {
            this.author = author;
            this.title = title;
            this.lyrics = lyrics;
        }

        public override string ToString()
        {
            return $"{author} - {title}\nLyrics:\n{lyrics}";
        }
    }
}
