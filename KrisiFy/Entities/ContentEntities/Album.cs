using KrisiFy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KrisiFy.Entities.ContentEntities
{
    public class Album : Playlist
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

        public void addSong(string albumName,Song songToAdd)
        {
            if (Name.Equals(albumName))
            {
                if (Songs.Count == 0)
                {
                    Songs.Add(songToAdd);
                    Console.WriteLine("Song {0} added in album!", songToAdd.Name);
                }
                else
                {
                    if (Songs.Contains(songToAdd))
                    {
                        Console.WriteLine("Song is already in this album!");
                    }
                    else
                    {
                        Songs.Add(songToAdd);
                        Console.WriteLine("Song added in album!");
                    }
                }
            }
        }

        public void removeSong(string albumName, Song songToRemove)
        {
            if (Name.Equals(albumName))
            {
                if (Songs.Count == 0)
                {
                    Console.WriteLine("The album is empty!");
                }
                else
                {
                    if (Songs.Contains(songToRemove))
                    {
                        Songs.Remove(songToRemove);
                        Console.WriteLine("Song is removed from album!");
                    }
                    else
                    {
                        Console.WriteLine("No such a song exists!");
                    }
                }
            }
        }

        public override string calculatePlaylistTime(Playlist playlist)
        {
            return base.calculatePlaylistTime(playlist);
        }

        public override string getPlaylistInfo(List<Playlist> PlaylistCollection, string playListName)
        {
            return base.getPlaylistInfo(PlaylistCollection, playListName);
        }

        public string getPlaylistInfo(List<Album> PlaylistCollection, string playListName,List<string> genres)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Album playlist in PlaylistCollection)
            {
                
                if (playlist.Name.Equals(playListName))
                {                    
                    sb.Append(String.Format("Album name is {0}\n", playlist.Name));
                    sb.Append(String.Format("Artist name is {0}\n", playlist.Artist.Username));

                    sb.Append(calculatePlaylistTime(playlist));
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
