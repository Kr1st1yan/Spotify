using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrisiFy.Entities.UserEntities
{
    public class Artist : User
    {
        private List<Album> albums;
        public Artist(string username, string password, string fullName, DateTime birthDate, List<string> genres, List<Album> albums, string type) : base(username, password, fullName, birthDate, genres, type)
        {
            this.Albums = albums;
        }

        public List<Album> Albums { get => albums; set => albums = value; }
        public override void infoPrint()
        {
            StringBuilder sb = new StringBuilder();
            string outputString = String.Format("Username: {0}\nPassword: {1}\nFull name: {2}\nBirth date: {3}\nGenres: \n", Username, Password, FullName, BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(outputString);

            if (Genres.Count == 0)
            {
                sb.Append("There are no genres.\n");
            }
            else
            {
                foreach (string genre in Genres)
                {
                    sb.Append(String.Format("    {0}\n", genre));
                }
            }

            sb.Append(String.Format("Albums: \n"));

            if (Albums.Count == 0)
            {
                sb.Append("There are no albums.\n");
            }
            else
            {
                int albumCounter = 1;

                foreach (Album album in Albums)
                {
                    sb.Append(String.Format("{0}. {1}\n", albumCounter, album.Name));
                    albumCounter++;
                }
            }
            Console.WriteLine(sb.ToString());
        }
        public override void playlistsPrint()
        {
            StringBuilder sb = new StringBuilder();

            if (Albums.Count == 0)
            {
                sb.Append("It is an empty collection.\n");
            }
            else
            {
                int albumsCounter = 1;

                foreach (Album album in albums)
                {
                    sb.Append(String.Format("{0}. Album - {1}\n", albumsCounter, album.Name));

                    if (album.Songs.Count == 0)
                    {
                        sb.Append("There are no songs in this album!\n");
                    }
                    else
                    {
                        int songCounter = 1;

                        foreach (Song song in album.Songs)
                        {
                            sb.Append(String.Format("    {0}. {1}\n", songCounter, song.Name));
                            songCounter++;
                        }
                    }
                    albumsCounter++;
                }
            }
            Console.WriteLine(sb.ToString());
        }


        public override void songsAndLengthPrint(string albumName)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            if (albums.Count == 0)
            {
                sb.Append("There are no Albums in this collection!\n");
            }
            else
            {
                Album album = new Album(albumName);
                List<Playlist> castedList = Albums.Cast<Playlist>().ToList();

                Console.WriteLine(album.getPlaylistInfo(Albums, albumName, Genres));
            }
        }
        public Album createAlbum(string name)
        {
            int count = 0;
            foreach (Album album in albums)
            {
                if (album.Name.Equals(name))
                {
                    count++;
                    Console.WriteLine("Album already exists!");
                    break;
                }
            }

            if (count == 0)
            {
                List<Song> songs = new List<Song>();
                List<string> genres = new List<string>();
                List<Album> albums1 = new List<Album>();
                Artist artist = new Artist("", "", "", DateTime.MinValue, genres, albums1, "artist");
                Album album = new Album(name, "", songs, artist, genres, "");

                return album;
            }
            return null;
        }
        public void deleteAlbum(string name)
        {
            int count = 0;
            foreach (Album album in albums)
            {
                if (album.Name.Equals(name))
                {
                    count++;
                    albums.Remove(album);
                    Console.WriteLine("Album deleted!");

                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Album with this name does not exist!");
            }
        }
        public void removeSongsFormAlbum(Song songToRemove, string albumName)
        {
            if (albums.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no albums to remove song from!");
            }
            else
            {
                foreach (Album album in albums)
                {
                    album.removeSong(albumName, songToRemove);
                }
            }
        }
        public void addSongsToAlbum(Song songToAdd, string albumName)
        {
            if (albums.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no albums to add this song to!");
            }
            else
            {
                foreach (Album album in albums)
                {
                    album.addSong(albumName, songToAdd);
                }
            }
        }
    }
}
