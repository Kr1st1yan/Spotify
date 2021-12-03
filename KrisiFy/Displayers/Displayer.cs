using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using KrisiFy.Logging;
using KrisiFy.ReadAndWrite;
using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Displayers
{
    class Displayer
    {
        public void ListenerDisplay()
        {
            Console.WriteLine("Here are your options: ");
            Console.WriteLine("[1] Print info about me");
            Console.WriteLine("[2] Print all my playlists");
            Console.WriteLine("[3] Print info about a playlist");
            Console.WriteLine("[4] Print my favourite songs");
            Console.WriteLine("[5] Create a playlist");
            Console.WriteLine("[6] Remove a playlist");
            Console.WriteLine("[7] Add songs to a playlist ");
            Console.WriteLine("[8] Remove songs from a playlist");
            Console.WriteLine("[9] Add songs to favourites");
            Console.WriteLine("[10] Remove songs from favourites");
            Console.WriteLine("[11] Log out");
        }

        public void ArtistDisplay()
        {
            Console.WriteLine("Here are your options: ");
            Console.WriteLine("[1] Print info about me");
            Console.WriteLine("[2] Print all my albums");
            Console.WriteLine("[3] Print info about a album");
            Console.WriteLine("[4] Create album");
            Console.WriteLine("[5] Remove album");
            Console.WriteLine("[6] Add songs to a album");
            Console.WriteLine("[7] Remove songs from a album");
            Console.WriteLine("[8] Log out");
        }

        public void LoginsDisplay(ReadFile readFile, Logger logger, Displayer displayer)
        {
            WriteOnFile writer = new WriteOnFile();

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            bool isLoggedIn = logger.Login(readFile, username, password);

            if (isLoggedIn)
            {
                if (logger.GetUserType(readFile, username) == Constants.LISTENER)
                {
                    Listener listener = readFile.Storage.Listeners[username];

                    if (listener == null)
                    {
                        Console.WriteLine("There was a mistake while logging in");
                    }
                    else
                    {
                        displayer.ListenerDisplay();
                        string cmnd = Console.ReadLine();

                        while (!cmnd.Equals("11"))
                        {
                            if (cmnd.Equals("1"))
                            {
                                listener.InfoPrint();
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("2"))
                            {
                                listener.PlaylistsPrint();
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("3"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string playlist = Console.ReadLine();
                                listener.SongsAndLengthPrint(playlist);
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("4"))
                            {
                                listener.FavouriteSongsPrint();
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("5"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string plName = Console.ReadLine();
                                Playlist playlist = listener.CreatePlaylist(plName);
                                if (playlist != null && !readFile.Storage.Playlists.ContainsKey(plName))
                                {
                                    readFile.Storage.Playlists.Add(plName, playlist);
                                    listener.PlaylistCollection.Add(playlist);
                                    Console.WriteLine("Playlist added successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("There was an error with creating the playlist");
                                }
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("6"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string plName = Console.ReadLine();
                                listener.RemovePlaylist(plName);
                                readFile.Storage.Playlists.Remove(plName);
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("7"))
                            {
                                Console.WriteLine("In which playlist do you want to add songs? ");
                                string plName = Console.ReadLine();

                                Console.WriteLine("Write the songs that you want to add to the playlist ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                if (readFile.Storage.Playlists.ContainsKey(plName))
                                {
                                    foreach (string song in songs)
                                    {
                                        if (readFile.Storage.Songs.ContainsKey(song))
                                        {
                                            listener.AddSongsToPlaylist(readFile.Storage.Songs[song], plName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No such song exists!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no playlist with this name!");
                                }

                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("8"))
                            {
                                Console.WriteLine("From which playlist do you want to remove songs? ");
                                string plName = Console.ReadLine();

                                Console.WriteLine("Write the songs that you want to remove from the playlist ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                if (readFile.Storage.Playlists.ContainsKey(plName))
                                {
                                    foreach (string song in songs)
                                    {
                                        if (readFile.Storage.Songs.ContainsKey(song))
                                        {
                                            listener.RemoveSongsFromPlaylist(readFile.Storage.Songs[song], plName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No such song exists!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no playlist with this name!");
                                }

                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("9"))
                            {

                                Console.WriteLine("Write the songs that you want to add in favourites: ");

                                string[] songs = Console.ReadLine().Split(", ");

                                foreach (string song in songs)
                                {
                                    if (readFile.Storage.Songs.ContainsKey(song))
                                    {
                                        listener.AddSongsToFavourites(readFile.Storage.Songs[song]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such song exists!");
                                    }
                                }

                                Console.WriteLine();
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("10"))
                            {
                                Console.WriteLine("Write the songs that you want to remove from favourites ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                foreach (string song in songs)
                                {
                                    if (readFile.Storage.Songs.ContainsKey(song))
                                    {
                                        listener.RemoveSongFromFavourites(readFile.Storage.Songs[song]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such song exists!");
                                    }
                                }
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect command!");
                                displayer.ListenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            cmnd = Console.ReadLine();
                        }
                        Console.WriteLine("Logged out..");
                        writer.Write(readFile.Storage.ReturnAllStorageInfo());
                    }
                }
                else if (logger.GetUserType(readFile, username) == Constants.ARTIST)
                {
                    Artist artist = readFile.Storage.Artists[username];

                    if (artist == null)
                    {
                        Console.WriteLine("There was a mistake while logging in");
                    }
                    else
                    {
                        displayer.ArtistDisplay();
                        string cmnd = Console.ReadLine();

                        while (!cmnd.Equals("8"))
                        {
                            if (cmnd.Equals("1"))
                            {
                                artist.InfoPrint();
                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("2"))
                            {
                                artist.PlaylistsPrint();
                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("3"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string album = Console.ReadLine();
                                artist.SongsAndLengthPrint(album);
                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("4"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string plName = Console.ReadLine();
                                Album album = artist.CreateAlbum(plName);

                                if (album != null && !readFile.Storage.Albums.ContainsKey(plName))
                                {
                                    readFile.Storage.Albums.Add(plName, album);
                                    artist.Albums.Add(album);
                                    Console.WriteLine("Album added successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("There was an error with creating the album");
                                }

                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("5"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string plName = Console.ReadLine();
                                artist.DeleteAlbum(plName);
                                readFile.Storage.Albums.Remove(plName);
                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("6"))
                            {
                                Console.WriteLine("In which album do you want to add songs? ");
                                string plName = Console.ReadLine();

                                Console.WriteLine("Write the songs that you want to add to the album ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                if (readFile.Storage.Albums.ContainsKey(plName))
                                {
                                    foreach (string song in songs)
                                    {
                                        if (readFile.Storage.Songs.ContainsKey(song))
                                        {
                                            artist.AddSongsToAlbum(readFile.Storage.Songs[song], plName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No such song exists!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no playlist with this name!");
                                }

                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("7"))
                            {
                                Console.WriteLine("From which album do you want to remove songs? ");
                                string plName = Console.ReadLine();
                                Console.WriteLine("Write the songs that you want to remove from the album ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                if (readFile.Storage.Albums.ContainsKey(plName))
                                {
                                    foreach (string song in songs)
                                    {
                                        if (readFile.Storage.Songs.ContainsKey(song))
                                        {
                                            artist.RemoveSongsFormAlbum(readFile.Storage.Songs[song], plName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No such song exists!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no playlist with this name!");
                                }

                                Console.WriteLine("Waiting for the next command...");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect command!");
                                displayer.ArtistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }

                            cmnd = Console.ReadLine();
                        }
                        Console.WriteLine("Logged out..");
                        writer.Write(readFile.Storage.ReturnAllStorageInfo());
                    }
                }
            }
            else
            {
                Console.WriteLine("No user found! Try again ...");
                LoginsDisplay(readFile, logger, displayer);
            }
        }
    }
}