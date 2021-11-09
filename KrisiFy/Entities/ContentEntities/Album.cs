using KrisiFy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.ContentEntities
{
    class Album : Playlist
    {
        private Artist artist;
        private List<string> genres;
        private string outYear;
        public Album(string name, string duration, List<Song> songs, Artist artist, List<string> genres, string outYear) : base(name, duration, songs)
        {
            this.Artist = artist;
            this.Genres = genres;
            this.OutYear = outYear;
        }

        public Album(string name) : base(name)
        {

        }

        public Artist Artist { get => artist; set => artist = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public string OutYear { get => outYear; set => outYear = value; }
    }
}
