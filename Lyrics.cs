using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BD
{
    internal class Lyrics
    {
        private string text;
        public string lyrics
        {
            
            get { return text.Substring(text.IndexOf('\n') + 1, text.Length - text.IndexOf('\n') - 1); }
            set { text = value; }
        }
    }
}
