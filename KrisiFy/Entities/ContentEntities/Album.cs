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
        private string genre;
        private DateTime outYear;
        public Album(string name, string duration, List<Song> songs, Artist artist, string genre, DateTime outYear) : base(name, duration, songs)
        {
            this.Artist = artist;
            this.Genre = genre;
            this.OutYear = outYear;
        }

        public string Genre { get => genre; set => genre = value; }
        public DateTime OutYear { get => outYear; set => outYear = value; }
        internal Artist Artist { get => artist; set => artist = value; }
    }
}
