using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BD
{
    internal class Song
    {
        public string title { get; set; }
        public string author { get; set; }
        public string lyrics { get; set; }

        public override string ToString()
        {
            return $"{author} - {title}\nLyrics:\n{lyrics}";
        }
    }
}
