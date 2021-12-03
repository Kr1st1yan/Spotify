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

        public override string CalculatePlaylistTime(Playlist playlist)
        {
            return base.CalculatePlaylistTime(playlist);
        }

        public override string GetPlaylistInfo(List<Playlist> PlaylistCollection, string playListName)
        {
            return base.GetPlaylistInfo(PlaylistCollection, playListName);
        }

        public string GetPlaylistInfo(List<Album> PlaylistCollection, string playListName, List<string> genres)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Album playlist in PlaylistCollection)
            {

                if (playlist.Name.Equals(playListName))
                {
                    sb.Append(String.Format("Album name is {0}\n", playlist.Name));
                    sb.Append(String.Format("Artist name is {0}\n", playlist.Artist.Username));

                    sb.Append(CalculatePlaylistTime(playlist));
                }
            }

            Console.WriteLine(sb);

            return sb.ToString();
        }

        public Artist Artist { get => artist; set => artist = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public string OutYear { get => outYear; set => outYear = value; }
    }
}
