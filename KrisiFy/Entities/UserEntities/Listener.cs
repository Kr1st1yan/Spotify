using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.UserEntities
{
    class Listener : User
    {
        List<Song> favouriteSongs;
        List<Playlist> playlistCollection;

        public List<Song> FavouriteSongs { get => favouriteSongs; set => favouriteSongs = value; }
        public List<Playlist> PlaylistCollection { get => playlistCollection; set => playlistCollection = value; }
        public Listener(string username, string password, string fullName, DateTime birthDate, List<string> genres, List<Song> favouriteSongs, List<Playlist> playlistCollection) : base(username, password, fullName, birthDate, genres)
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

            if (FavouriteSongs.Count == 0)
            {
                sb.Append("There are no songs in favourites.\n");
            }
            else
            {
                int songCounter = 1;
                foreach (Song song in FavouriteSongs)
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

            if (FavouriteSongs.Count == 0)
            {
                sb.Append("There are no songs in favourites.\n");
            }
            else
            {
                int songCounter = 1;
                foreach (Song song in FavouriteSongs)
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
                foreach (Playlist playlist in PlaylistCollection)
                {
                    if (playlist.Name.Equals(playListName))
                    {
                        count++;

                        sb.Append(String.Format("Playlist name is {0}\n", playlist.Name));

                        if (playlist.Songs.Count == 0)
                        {
                            sb.Append("There are no songs in this playlist!\n");
                        }
                        else
                        {
                            int songCounter = 1;
                            int allHours = 0;
                            int allMinutes = 0;
                            int allSeconds = 0;

                            sb.Append(String.Format("The songs in the playlist are:\n"));
                            foreach (Song song in playlist.Songs)
                            {
                                sb.Append(String.Format("    {0}. {1}\n", songCounter, song.Name));

                                string[] data = song.Duration.Split(":");

                                if (data.Length == 3)
                                {
                                    int hours = int.Parse(data[0]);
                                    int minutes = int.Parse(data[1]);
                                    int seconds = int.Parse(data[2]);

                                    allSeconds += seconds;
                                    if (allSeconds > 59)
                                    {
                                        allMinutes++;
                                        allSeconds -= 60;
                                    }

                                    allMinutes += minutes;
                                    if (allMinutes > 59)
                                    {
                                        allHours++;
                                        allMinutes -= 60;
                                    }
                                    allHours += hours;
                                }
                                else
                                {
                                    int minutes = int.Parse(data[0]);
                                    int seconds = int.Parse(data[1]);

                                    allSeconds += seconds;
                                    if (allSeconds > 59)
                                    {
                                        allMinutes++;
                                        allSeconds -= 60;
                                    }

                                    allMinutes += minutes;
                                    if (allMinutes > 59)
                                    {
                                        allHours++;
                                        allMinutes -= 60;
                                    }
                                }
                            }
                            string outputHours = allHours.ToString();
                            string outputMinutes = allMinutes.ToString();
                            string outputSeconds = allSeconds.ToString();
                            if (allHours < 10)
                            {
                                outputHours = "0" + allHours.ToString();
                            }
                            if (allMinutes < 10)
                            {
                                outputMinutes = "0" + allMinutes.ToString();
                            }
                            if (allSeconds < 10)
                            {
                                outputSeconds = "0" + allSeconds.ToString();
                            }
                            sb.Append(String.Format("Playlist length is: {0}:{1}:{2}\n", allHours, allMinutes, allSeconds));
                            playlist.Duration = String.Format("{0}:{1}:{2}\n", allHours, allMinutes, allSeconds);
                        }
                    }
                    if (count == 0)
                    {
                        sb.Append("There is no playlist with this name");
                    }
                }
            }
            Console.WriteLine(sb.ToString());
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
            if (FavouriteSongs.Count == 0)
            {
                FavouriteSongs.Add(songToAdd);
                Console.WriteLine("Song {0} added in favourites!", songToAdd.Name);
            }
            else
            {
                if (FavouriteSongs.Contains(songToAdd))
                {
                    Console.WriteLine("Song is already in this playlist!");
                }
                else
                {
                    FavouriteSongs.Add(songToAdd);
                    Console.WriteLine("Song added in favourites!");
                }
            }
        }

        public void removeSongFromFavourites(Song songToRemove)
        {
            if (FavouriteSongs.Count == 0)
            {
                Console.WriteLine("Favourite songs is empty!");
            }
            else
            {
                if (FavouriteSongs.Contains(songToRemove))
                {
                    FavouriteSongs.Remove(songToRemove);
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
                    if (playlist.Name.Equals(playListName))
                    {
                        if (playlist.Songs.Count == 0)
                        {
                            playlist.Songs.Add(songToAdd);
                            Console.WriteLine("Song {0} added in playlist!", songToAdd.Name);
                        }
                        else
                        {
                            if (playlist.Songs.Contains(songToAdd))
                            {
                                Console.WriteLine("Song is already in this playlist!");
                            }
                            else
                            {
                                playlist.Songs.Add(songToAdd);
                                Console.WriteLine("Song added in playlist!");
                            }
                        }
                    }
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
                    if (playlist.Name.Equals(playListName))
                    {
                        if (playlist.Songs.Count == 0)
                        {
                            Console.WriteLine("The playlist is empty!");
                        }
                        else
                        {
                            if (playlist.Songs.Contains(songToRemove))
                            {
                                playlist.Songs.Remove(songToRemove);
                                Console.WriteLine("Song is removed from playlist!");
                            }
                            else
                            {
                                Console.WriteLine("No such a song exists!");
                            }
                        }
                    }
                }
            }
        }
    }
}
