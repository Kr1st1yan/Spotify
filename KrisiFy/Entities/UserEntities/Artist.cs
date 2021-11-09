using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.UserEntities
{
    class Artist : User
    {
        private List<Album> albums;
        public Artist(string username, string password, string fullName, DateTime birthDate, List<string> genres, List<Album> albums) : base(username, password, fullName, birthDate, genres)
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

            foreach (Album album in albums)
            {
                if (album.Name.Equals(albumName))
                {
                    count++;
                    string a = string.Format("Album name is {0}\nArtist: {1}\nIt was out on {2}\n", album.Name, album.Artist.Username, album.OutYear);
                    sb.Append(a);

                    if (album.Songs.Count == 0)
                    {
                        sb.Append("There are no songs in this album!\n");
                    }
                    else
                    {
                        int songCounter = 1;
                        int allHours = 0;
                        int allMinutes = 0;
                        int allSeconds = 0;

                        sb.Append(String.Format("The genres in the album are:\n"));
                        foreach (string genre in album.Genres)
                        {
                            sb.Append(String.Format("{0}:\n", genre));
                        }
                        sb.Append(String.Format("The songs in the album are:\n"));
                        foreach (Song song in album.Songs)
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

                        sb.Append(String.Format("Album length is: {0}:{1}:{2}\n", outputHours, outputMinutes, outputSeconds));
                        album.Duration = (String.Format("{0}:{1}:{2}", outputHours, outputMinutes, outputSeconds));
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
                sb.Append("There is no album with this name");
            }
            Console.WriteLine(sb.ToString());
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
                Artist artist = new Artist("", "", "", DateTime.MinValue, genres, albums1);
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
                    if (album.Name.Equals(albumName))
                    {
                        if (album.Songs.Count == 0)
                        {
                            Console.WriteLine("The album is empty!");
                        }
                        else
                        {
                            if (album.Songs.Contains(songToRemove))
                            {
                                album.Songs.Remove(songToRemove);
                                Console.WriteLine("Song is removed from album!");
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
                    if (album.Name.Equals(albumName))
                    {
                        if (album.Songs.Count == 0)
                        {
                            album.Songs.Add(songToAdd);
                            Console.WriteLine("Song {0} added in album!", songToAdd.Name);
                        }
                        else
                        {
                            if (album.Songs.Contains(songToAdd))
                            {
                                Console.WriteLine("Song is already in this album!");
                            }
                            else
                            {
                                album.Songs.Add(songToAdd);
                                Console.WriteLine("Song added in album!");
                            }
                        }
                    }
                }
            }
        }
    }
}
