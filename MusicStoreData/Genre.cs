using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class Genre
    {

        public string Name { get; set; }
        public int GenreId { get; set; }
        public string Description { get; set; }

        override
        public string ToString()
        {
            return Name;
        }
    }
}
