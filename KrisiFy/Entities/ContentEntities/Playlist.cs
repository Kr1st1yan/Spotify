using KrisiFy.Entities.ContentEntities.InterfaceAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.ContentEntities
{
    class Playlist : Content
    {
        private List<Song> songs = new List<Song>();
        public Playlist(string name) : base(name)
        {

        }

        public Playlist(string name, string duration, List<Song> songs) : base(name, duration)
        {
            this.songs = songs;
        }

        public void AddSong(Song songToAdd)
        {
            if (Songs.Count == 0)
            {
                Songs.Add(songToAdd);

                Console.WriteLine("Song {0} added in {1}!", songToAdd.Name, this.GetType().Name);
            }
            else
            {
                if (Songs.Contains(songToAdd))
                {
                    Console.WriteLine("Song is already in this {0}!", this.GetType().Name);
                }
                else
                {
                    Songs.Add(songToAdd);
                    Console.WriteLine("Song added in {0}!", this.GetType().Name);
                }
            }
        }

        public void RemoveSong(Song songToRemove)
        {

            if (Songs.Count == 0)
            {
                Console.WriteLine("The {0} is empty!", this.GetType().Name);
            }
            else
            {
                if (Songs.Contains(songToRemove))
                {
                    Songs.Remove(songToRemove);
                    Console.WriteLine("Song is removed from {0}!", this.GetType().Name);
                }
                else
                {
                    Console.WriteLine("No such a song exists!");
                }
            }
        }

        public List<Song> Songs { get => songs; set => songs = value; }

        virtual public string CalculatePlaylistTime(Playlist playlist)
        {
            StringBuilder sb = new StringBuilder();

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
                sb.Append(String.Format("Playlist length is: {0}:{1}:{2}\n", outputHours, outputMinutes, outputSeconds));
                playlist.Duration = String.Format("{0}:{1}:{2}\n", outputHours, outputMinutes, outputSeconds);
            }

            return sb.ToString();
        }

        virtual public string GetPlaylistInfo(List<Playlist> PlaylistCollection, string playListName)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Playlist playlist in PlaylistCollection)
            {

                if (playlist.Name.Equals(playListName))
                {
                    sb.Append(String.Format("Playlist name is {0}\n", playlist.Name));
                    sb.Append(CalculatePlaylistTime(playlist));
                }
            }

            return sb.ToString();
        }
    }
}
