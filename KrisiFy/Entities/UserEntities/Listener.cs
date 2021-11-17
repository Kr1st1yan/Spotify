using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KrisiFy.Entities.UserEntities
{
    public class Listener : User
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

        public override void playlistsPrint()
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

        public void favouriteSongsPrint()
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

        public override void songsAndLengthPrint(string playListName)
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
                Console.WriteLine(playlist.getPlaylistInfo(PlaylistCollection, playListName));
            }
        }

        public Playlist createPlaylist(string name)
        {
            int count = 0;
            foreach (Playlist playlist1 in PlaylistCollection)
            {
                if (playlist1.Name.Equals(name))
                {
                    count++;
                    Console.WriteLine("Playlist already exists!");
                    break;
                }
            }

            if (count == 0)
            {
                List<Song> songs = new List<Song>();
                Playlist playlist = new Playlist(name, "", songs);

                return playlist;
            }
            return null;
        }

        public void removePlaylist(string name)
        {
            int count = 0;
            foreach (Playlist playlist1 in PlaylistCollection)
            {
                if (playlist1.Name.Equals(name))
                {
                    count++;
                    PlaylistCollection.Remove(playlist1);
                    Console.WriteLine("Playlist removed!");

                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Playlist with this name does not exist!");
            }
        }

        public void addSongsToFavourites(Song songToAdd)
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

        public void removeSongFromFavourites(Song songToRemove)
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

        public void addSongsToPlaylist(Song songToAdd, string playListName)
        {
            if (playlistCollection.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no playlists to remove song from!");
            }
            else
            {
                foreach (Playlist playlist in PlaylistCollection)
                {
                    playlist.addSong(playListName, songToAdd);
                }
            }
        }

        public void removeSongsFromPlaylist(Song songToRemove, string playListName)
        {
            if (playlistCollection.Count == 0)
            {
                Console.WriteLine("Collection is empty, there are no playlists to remove song from!");
            }
            else
            {
                foreach (Playlist playlist in PlaylistCollection)
                {
                    playlist.removeSong(playListName, songToRemove);
                }
            }
        }
    }
}
