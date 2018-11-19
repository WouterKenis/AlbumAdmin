using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class Artist
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
