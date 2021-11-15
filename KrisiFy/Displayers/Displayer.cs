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
        public void listenerDisplay()
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

        public void artistDisplay()
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

        public void loginsDisplay(ReadFile readFile, Logger logger, Displayer displayer)
        {
            WriteOnFile writer = new WriteOnFile();

            Console.WriteLine("Enter username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            bool isLoggedIn = logger.login(readFile, username, password);

            if (isLoggedIn)
            {
                if (logger.getUserType(readFile, username) == Constants.LISTENER)
                {
                    Listener listener = readFile.Storage.Listeners[username];

                    if (listener == null)
                    {
                        Console.WriteLine("There was a mistake while logging in");
                    }
                    else
                    {
                        displayer.listenerDisplay();
                        string cmnd = Console.ReadLine();

                        while (!cmnd.Equals("11"))
                        {
                            if (cmnd.Equals("1"))
                            {
                                listener.infoPrint();
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("2"))
                            {
                                listener.playlistsPrint();
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("3"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string playlist = Console.ReadLine();
                                listener.songsAndLengthPrint(playlist);
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("4"))
                            {
                                listener.favouriteSongsPrint();
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("5"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string plName = Console.ReadLine();
                                Playlist playlist = listener.createPlaylist(plName);
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
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("6"))
                            {
                                Console.WriteLine("Enter playlist name: ");
                                string plName = Console.ReadLine();
                                listener.removePlaylist(plName);
                                readFile.Storage.Playlists.Remove(plName);
                                displayer.listenerDisplay();
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
                                            listener.addSongsToPlaylist(readFile.Storage.Songs[song], plName);
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

                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("8"))
                            {
                                Console.WriteLine("Write the songs that you want to remove from favourites ?");
                                string[] songs = Console.ReadLine().Split(", ");

                                foreach (string song in songs)
                                {
                                    if (readFile.Storage.Songs.ContainsKey(song))
                                    {
                                        listener.removeSongFromFavourites(readFile.Storage.Songs[song]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such song exists!");
                                    }
                                }

                                displayer.listenerDisplay();
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
                                        listener.addSongsToFavourites(readFile.Storage.Songs[song]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such song exists!");
                                    }
                                }

                                Console.WriteLine();
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("10"))
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
                                            listener.removeSongsFromPlaylist(readFile.Storage.Songs[song], plName);
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

                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect command!");
                                displayer.listenerDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }

                            cmnd = Console.ReadLine();
                        }
                        Console.WriteLine("Logged out..");
                        writer.write(readFile.Storage.returnAllStorageInfo());
                    }
                }
                else if (logger.getUserType(readFile, username) == Constants.ARTIST)
                {
                    Artist artist = readFile.Storage.Artists[username];

                    if (artist == null)
                    {
                        Console.WriteLine("There was a mistake while logging in");
                    }
                    else
                    {
                        displayer.artistDisplay();
                        string cmnd = Console.ReadLine();

                        while (!cmnd.Equals("8"))
                        {
                            if (cmnd.Equals("1"))
                            {
                                artist.infoPrint();
                                displayer.artistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("2"))
                            {
                                artist.playlistsPrint();
                                displayer.artistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("3"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string album = Console.ReadLine();
                                artist.songsAndLengthPrint(album);
                                displayer.artistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("4"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string plName = Console.ReadLine();
                                Album album = artist.createAlbum(plName);

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

                                displayer.artistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }
                            else if (cmnd.Equals("5"))
                            {
                                Console.WriteLine("Enter album name: ");
                                string plName = Console.ReadLine();
                                artist.deleteAlbum(plName);
                                readFile.Storage.Albums.Remove(plName);
                                displayer.artistDisplay();
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
                                            artist.addSongsToAlbum(readFile.Storage.Songs[song], plName);
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

                                displayer.artistDisplay();
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
                                            artist.removeSongsFormAlbum(readFile.Storage.Songs[song], plName);
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
                                displayer.artistDisplay();
                                Console.WriteLine("Waiting for the next command...");
                            }

                            cmnd = Console.ReadLine();
                        }
                        Console.WriteLine("Logged out..");
                        writer.write(readFile.Storage.returnAllStorageInfo());
                    }
                }
            }
            else
            {
                Console.WriteLine("No user found! Try again ...");
                loginsDisplay(readFile, logger, displayer);
            }
        }
    }
}