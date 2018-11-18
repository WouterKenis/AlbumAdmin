using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreData
{
    public class Album
    {
        public int AllbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

    }
}