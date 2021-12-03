using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using KrisiFy.ReadAndWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.UserEntities
{
    class Listener : User
    {
        Playlist favouriteSongs;
        List<Playlist> playlistCollection;
        public List<Playlist> PlaylistCollection { get => playlistCollection; set => playlistCollection = value; }
        public Playlist FavouriteSongs { get => favouriteSongs; set => favouriteSongs = value; }

        public Listener(string username, string password, string fullName, DateTime birthDate, List<string> genres, Playlist favouriteSongs, List<Playlist> playlistCollection, string type) : base(username, password, fullName, birthDate, genres, type)
        {
            this.FavouriteSongs = favouriteSongs;
            this.PlaylistCollection = playlistCollection;
        }

        public override void InfoPrint()
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

            sb.Append(String.Format("Favourite songs: \n"));

            if (FavouriteSongs.Songs.Count == 0)
            {
                sb.Append("There are no songs in favourites.\n");
            }
            else
            {
                int songCounter = 1;
                foreach (Song song in FavouriteSongs.Songs)
                {
                    sb.Append(String.Format("{0}. {1}\n", songCounter, song.Name));
                    songCounter++;
                }
            }

            sb.Append(String.Format("Playlists: \n"));

            if (PlaylistCollection.Count == 0)
            {
                sb.Append("There are no playlists.\n");
            }
            else
            {
                int playlistCounter = 1;

                foreach (Playlist playlist in PlaylistCollection)
                {
                    sb.Append(String.Format("{0}. {1}\n", playlistCounter, playlist.Name));
                    playlistCounter++;
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public override void PlaylistsPrint()
        {
            StringBuilder sb = new StringBuilder();

            if (PlaylistCollection.Count == 0)
            {
                sb.Append("It is an empty collection.\n");
            }
            else
            {
                int playlistCounter = 1;

                foreach (Playlist playlist in PlaylistCollection)
                {
                    sb.Append(String.Format("{0}. Playlist - {1}\n", playlistCounter, playlist.Name));
                    playlistCounter++;
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public void FavouriteSongsPrint()
        {
            StringBuilder sb = new StringBuilder();

            if (FavouriteSongs.Songs.Count == 0)
            {
                sb.Append("There are no songs in favourites.\n");
            }
            else
            {
                int songCounter = 1;
                foreach (Song song in FavouriteSongs.Songs)
                {
                    sb.Append(String.Format("{0}. {1}:\n", songCounter, song.Name));
                    sb.Append(String.Format("    Duration: {0}\n", song.Duration));
                    sb.Append(String.Format("    This song is from album: {0}\n", song.Album.Name));
                    sb.Append(String.Format("    This artist is: {0}\n", song.Artist.FullName));
                    sb.Append(String.Format("    This genre is: {0}\n", song.Genre));
                    sb.Append(String.Format("    It was out on: {0}\n", song.OutYear));

                    songCounter++;
                }
            }
            Console.WriteLine(sb.ToString());
        }

        public override void SongsAndLengthPrint(string playListName)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            if (PlaylistCollection.Count == 0)
            {
                sb.Append("There are no playlists in the collection!\n");
            }
            else
            {
                Playlist playlist = new Playlist(playListName);
                Console.WriteLine(playlist.GetPlaylistInfo(PlaylistCollection, playListName));
            }
        }

        public Playlist CreatePlaylist(string name)
        {
            Playlist playlist = playlistCollection.Find(pl => pl.Name == name);

            if (playlist == null)
            {
                List<Song> songs = new List<Song>();
                Playlist playlistToReturn = new Playlist(name, "", songs);

                return playlistToReturn;
            }
            else
            {
                Console.WriteLine("Playlist already exists!");
            }

            return null;
        }

        public void RemovePlaylist(string name)
        {
            Playlist playlist = playlistCollection.Find(pl => pl.Name == name);

            if (playlist == null)
            {
                Console.WriteLine("Playlist with this name does not exist!");
            }
            else
            {
                Console.WriteLine("Playlist was removed succesfully!");
                playlistCollection.Remove(playlist);
            }
        }

        public void AddSongsToFavourites(Song songToAdd)
        {
            if (FavouriteSongs.Songs.Count == 0)
            {
                FavouriteSongs.Songs.Add(songToAdd);
                Console.WriteLine("Song {0} added in favourites!", songToAdd.Name);
            }
            else
            {
                if (FavouriteSongs.Songs.Contains(songToAdd))
                {
                    Console.WriteLine("Song is already in this playlist!");
                }
                else
                {
                    FavouriteSongs.Songs.Add(songToAdd);
                    Console.WriteLine("Song {0} added in favourites!", songToAdd);
                }
            }
        }

        public void RemoveSongFromFavourites(Song songToRemove)
        {
            if (FavouriteSongs.Songs.Count == 0)
            {
                Console.WriteLine("Favourite songs is empty!");
            }
            else
            {
                if (FavouriteSongs.Songs.Contains(songToRemove))
                {
                    FavouriteSongs.Songs.Remove(songToRemove);
                    Console.WriteLine("Song is removed from favourites!");
                }
                else
                {
                    Console.WriteLine("Song does not exist in favourites!");
                }
            }
        }

        public void AddSongsToPlaylist(Song songToAdd, string playListName)
        {
            if (playlistCollection.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no playlists to remove song from!");
            }
            else
            {
                Playlist playlist = playlistCollection.Find(pl => pl.Name == playListName);

                if (playlist == null)
                {
                    Console.WriteLine("There is no playlist with this name in your playlists!");
                }
                else
                {
                    playlist.AddSong(songToAdd);
                }
            }
        }

        public void RemoveSongsFromPlaylist(Song songToRemove, string playListName)
        {
            if (playlistCollection.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no playlists to remove song from!");
            }
            else
            {
                Playlist playlist = playlistCollection.Find(pl => pl.Name == playListName);

                if (playlist == null)
                {
                    Console.WriteLine("There is no playlist with this name in your playlists!");
                }
                else
                {
                    playlist.RemoveSong(songToRemove);
                }
            }
        }
    }
}
