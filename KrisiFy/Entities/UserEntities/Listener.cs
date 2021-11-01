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

        internal List<Song> FavouriteSongs { get => favouriteSongs; set => favouriteSongs = value; }
        internal List<Playlist> PlaylistCollection { get => playlistCollection; set => playlistCollection = value; }

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

                    if (playlist.Songs.Count == 0)
                    {
                        sb.Append("There are no songs in this playlist\n");
                    }
                    else
                    {
                        int songCounter = 1;

                        int allHours = 0;
                        int allMinutes = 0;
                        int allSeconds = 0;
                        foreach (Song song in playlist.Songs)
                        {
                            sb.Append(String.Format("    {0}. {1}\n", songCounter, song.Name));


                        }

                    }
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
                    sb.Append(String.Format("    It was out on: {0}\n", song.OutYear.ToString("dd/MM/yyyy")));

                    songCounter++;
                }
            }

            Console.WriteLine(sb.ToString());

        }

        public override void songsAndLengthPrint(string playListName)
        {
            int count = 0;
            StringBuilder sb = new StringBuilder();

            foreach (Playlist playlist in playlistCollection)
            {
                if (playlist.Name.Equals(playListName))
                {
                    count++;

                    sb.Append(String.Format("Album name is {0}\n", playlist.Name));

                    if (playlist.Songs.Count == 0)
                    {
                        sb.Append("There are no songs in this playlist\n");
                    }
                    else
                    {
                        int songCounter = 1;

                        int allHours = 0;
                        int allMinutes = 0;
                        int allSeconds = 0;
                        sb.Append(String.Format("The songs in the album are:\n"));
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
                        if(allHours < 10)
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

                        sb.Append(String.Format("Playlist length is: {0}:{1}:{2}\n", outputHours, outputMinutes, outputSeconds));

                    }
                    break;
                }
                else
                {
                    continue;
                }
                

            }
            if (count == 0)
            {
                sb.Append("there is no playlist with this name");
            }
            Console.WriteLine(sb.ToString());
        }

        public void createPlaylist(string name)
        {
            int count = 0;
            foreach (Playlist playlist1 in playlistCollection)
            {
                if (playlist1.Name.Equals(name))
                {
                    count++;
                    Console.WriteLine("Playlist already exists!");
                    break;
                }
            }

            if(count == 0)
            {

                List<Song> songs = new List<Song>();

                Playlist playlist = new Playlist(name, "", songs);

                playlistCollection.Add(playlist);
                Console.WriteLine("Playlist added successfully!");
            }
     
        }

        public void removePlaylist(string name)
        {
            int count = 0;
            foreach (Playlist playlist1 in playlistCollection)
            {
                if (playlist1.Name.Equals(name))
                {
                    count++;
                    playlistCollection.Remove(playlist1);
                    Console.WriteLine("Playlist deleted!");

                    break;
                }
            }
            if (count == 0)
            {              
                Console.WriteLine("Playlist with this name does not exist!");
            }

        }

        public void addSongToFavourites(Song song)
        {
            int count = 0;
            foreach (Song song1 in favouriteSongs)
            {
                if (song1.Name.Equals(song.Name))
                {
                    count++;
                    Console.WriteLine("The song is already in favourites!");

                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Song added successfully!");
                favouriteSongs.Add(song);
            }
        }

        public void removeSongFromFavourites(string name)
        {
            int count = 0;
            foreach (Song song1 in favouriteSongs)
            {
                if (song1.Name.Equals(name))
                {
                    count++;
                    Console.WriteLine("The song is removed from favourites!");
                    favouriteSongs.Remove(song1);
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("The song does not exist in favourites!");                
            }
        }

        public void addSongToPlaylist(Song song, string playListName)
        {
            int count = 0;
            foreach (Playlist playlist in playlistCollection)
            {
                if (playlist.Name.Equals(playListName))
                {
                    count++;

                    if(playlist.Songs.Count == 0)
                    {
                        playlist.Songs.Add(song);
                        Console.WriteLine("Song added in playlist!");
                    }
                    else
                    {
                        foreach (Song song1 in playlist.Songs)
                        {
                            if (song1.Name.Equals(song.Name))
                            {
                                Console.WriteLine("Song is already in this playlist!");
                                break;
                            }
                            playlist.Songs.Add(song);
                            Console.WriteLine("Song added in playlist!");
                            break;
                        }
                    }
              }

            }
            if(count == 0)
            {
                Console.WriteLine("A playlist with this name was not found!");
            }

        }

        public void removeSongFromPlaylist(Song song, string playListName)
        {
            int count = 0;
            foreach (Playlist playlist in playlistCollection)
            {
                if (playlist.Name.Equals(playListName))
                {
                    count++;

                    if (playlist.Songs.Count == 0)
                    {
                        Console.WriteLine("Playlist is Empty!");
                    }
                    else
                    {
                        int songCounter = 0;
                        foreach (Song song1 in playlist.Songs)
                        {
                            if (song1.Name.Equals(song.Name))
                            {
                                songCounter++;
                                playlist.Songs.Remove(song);
                                Console.WriteLine("Song is removed from the playlist!");
                                break;
                            }                           
                        }
                        if(songCounter == 0)
                        {
                            Console.WriteLine("A song with this name is not found!");
                        }
                    }
                }

            }
            if (count == 0)
            {
                Console.WriteLine("A playlist with this name was not found!");
            }
        }

    }

    
}
