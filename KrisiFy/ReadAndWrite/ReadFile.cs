using KrisiFy.DataStore;
using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KrisiFy.ReadAndWrite
{
    class ReadFile
    {
        Storage storage = new Storage();

        public Storage Storage { get => storage; set => storage = value; }

        public void read()
        {
            Regex userRegex = new Regex("(?<=<user>)<(?<username>\\S+)>\\((?<password>.+)\\){(?<type>[a-z]+)}(?=<\\/user>)");
            Regex songRegex = new Regex("(?<=<song>)<(?<name>.+)>\\[(?<length>[0-9]{1,}:[0-9]{2})\\](?=<\\/song)");
            Regex listenerRegex = new Regex("(?<=<listener>)<(?<username>\\S+)><(?<fullName>\\D+)>\\[(?<dateOfBirth>\\d+\\/\\d+\\/\\d+)\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(likedSongs: \\[(?<likedSongs>.*?)\\]\\)\\(playlists: \\[(?<playlists>.*?)\\]\\)(?=<\\/listener>)");
            Regex artistRegex = new Regex("(?<=<artist>)<(?<artistName>\\S+)><(?<fullName>\\D+ [A-Z][a-z]+|[A-Z][a-z]+)>\\[(?<dateOfBirth>\\d+\\/\\d+\\/\\d+)\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(albums: \\[(?<albums>.*?)\\]\\)(?=<\\/artist>)");
            Regex albumRegex = new Regex("(?<=<album>)<(?<albumName>.*?)>\\[(?<year>\\d{4})\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(songs: \\[(?<songs>.*?)\\]\\)(?=<\\/album>)");
            Regex playlistRegex = new Regex("(?<=<playlists>)<(?<playlistName>.*?)>\\(songs: \\[(?<songs>.*?)\\]\\)(?=<\\/playlists>)");

            WriteOnFile writer = new WriteOnFile();

            foreach (string line in System.IO.File.ReadLines(Constants.PATH_TO_TEXT_FILE))
            {
                if (line != null)
                {
                    if (userRegex.IsMatch(line))
                    {
                        string username = userRegex.Match(line).Groups["username"].Value;
                        string password = userRegex.Match(line).Groups["password"].Value;
                        string type = userRegex.Match(line).Groups["type"].Value;

                        if (type.Equals(Constants.LISTENER))
                        {
                            List<string> genres = new List<string>();
                            Playlist favouriteSongs = new Playlist("");
                            List<Playlist> playlists = new List<Playlist>();
                            Listener listener = new Listener(username, password, "", DateTime.MinValue, genres, favouriteSongs, playlists, Constants.LISTENER);
                            Storage.Listeners.Add(username, listener);
                            Storage.Users.Add(username, listener);
                        }
                        else if (type.Equals(Constants.ARTIST))
                        {
                            List<string> genres = new List<string>();
                            List<Album> albums = new List<Album>();
                            Artist artist = new Artist(username, password, "", DateTime.MinValue, genres, albums, Constants.ARTIST);
                            Storage.Artists.Add(username, artist);
                            Storage.Users.Add(username, artist);
                        }
                    }
                    else if (listenerRegex.IsMatch(line))
                    {
                        string username = listenerRegex.Match(line).Groups["username"].Value;
                        string fullName = listenerRegex.Match(line).Groups["fullName"].Value;
                        string dateOfBirth = listenerRegex.Match(line).Groups["dateOfBirth"].Value;
                        string genres = listenerRegex.Match(line).Groups["genres"].Value.Replace("\'", "");
                        string likedSongs = listenerRegex.Match(line).Groups["likedSongs"].Value.Replace("\'", "");
                        string playlists = listenerRegex.Match(line).Groups["playlists"].Value.Replace("\'", "");

                        List<string> genresInput = genres.Split(", ").ToList<string>();
                        List<string> likedSongsInput = likedSongs.Split(", ").ToList<string>();
                        List<string> playlistsInput = playlists.Split(", ").ToList<string>();

                        Storage.Listeners[username].FullName = fullName;
                        Storage.Listeners[username].BirthDate = DateTime.Parse(dateOfBirth);

                        foreach (string name in genresInput)
                        {
                            if (name != "")
                            {
                                Storage.Listeners[username].Genres.Add(name);
                            }
                        }

                        foreach (string name in likedSongsInput)
                        {
                            if (name != "")
                            {
                                Song song = new Song(name);
                                if (!Storage.Songs.ContainsKey(name))
                                {
                                    Storage.Songs.Add(name, song);
                                }
                                Storage.Listeners[username].FavouriteSongs.Songs.Add(song);
                            }
                        }

                        foreach (string name in playlistsInput)
                        {
                            if (name != "")
                            {
                                Playlist playlist = new Playlist(name);
                                if (!Storage.Playlists.ContainsKey(name))
                                {
                                    Storage.Playlists.Add(name, playlist);
                                }
                                Storage.Listeners[username].PlaylistCollection.Add(playlist);
                            }
                        }
                    }
                    else if (artistRegex.IsMatch(line))
                    {
                        string username = artistRegex.Match(line).Groups["artistName"].Value;
                        string fullName = artistRegex.Match(line).Groups["fullName"].Value;
                        string dateOfBirth = artistRegex.Match(line).Groups["dateOfBirth"].Value;
                        string genres = artistRegex.Match(line).Groups["genres"].Value.Replace("\'", "");
                        string albums = artistRegex.Match(line).Groups["albums"].Value.Replace("\'", "");

                        List<string> genresInput = genres.Split(", ").ToList<string>();
                        List<string> albumsInput = albums.Split(", ").ToList<string>();

                        Storage.Artists[username].FullName = fullName;
                        Storage.Artists[username].BirthDate = DateTime.Parse(dateOfBirth);

                        foreach (string name in genresInput)
                        {
                            if (name != "")
                            {
                                Storage.Artists[username].Genres.Add(name);
                            }
                        }

                        foreach (string name in albumsInput)
                        {
                            if (name != "")
                            {
                                Album album = new Album(name);
                                if (!Storage.Albums.ContainsKey(name))
                                {
                                    Storage.Albums.Add(name, album);
                                }
                                Storage.Albums[name].Artist = Storage.Artists[username];
                                Storage.Artists[username].Albums.Add(album);
                            }
                        }
                    }
                    else if (albumRegex.IsMatch(line))
                    {
                        string albumName = albumRegex.Match(line).Groups["albumName"].Value;
                        string year = albumRegex.Match(line).Groups["year"].Value;
                        string genres = albumRegex.Match(line).Groups["genres"].Value.Replace("\'", "");
                        string songs = albumRegex.Match(line).Groups["songs"].Value.Replace("\'", "");

                        List<string> genresInput = genres.Split(", ").ToList<string>();
                        List<string> songsInput = songs.Split(", ").ToList<string>();

                        if (!Storage.Albums.ContainsKey(albumName))
                        {
                            Album album = new Album(albumName);
                            Storage.Albums[albumName] = album;
                        }

                        Storage.Albums[albumName].OutYear = year;

                        foreach (string name in genresInput)
                        {
                            if (name != "")
                            {
                                if (Storage.Albums[albumName].Genres == null)
                                {
                                    List<string> genresList = new List<string>();
                                    Storage.Albums[albumName].Genres = genresList;
                                    Storage.Albums[albumName].Genres.Add(name);
                                }
                                else
                                {
                                    Storage.Albums[albumName].Genres.Add(name);
                                }
                            }
                        }

                        foreach (string name in songsInput)
                        {
                            if (name != "")
                            {
                                if (Storage.Songs.ContainsKey(name))
                                {
                                    Storage.Albums[albumName].Songs.Add((Storage.Songs[name]));
                                }
                                else
                                {
                                    Song song = new Song(name);
                                    Storage.Songs.Add(name, song);
                                    Storage.Albums[albumName].Songs.Add(song);
                                }
                                Storage.Songs[name].Artist = Storage.Albums[albumName].Artist;
                                Storage.Songs[name].Album = Storage.Albums[albumName];
                                Storage.Songs[name].OutYear = Storage.Albums[albumName].OutYear;
                            }
                        }
                    }
                    else if (songRegex.IsMatch(line))
                    {
                        string name = songRegex.Match(line).Groups["name"].Value;
                        string length = songRegex.Match(line).Groups["length"].Value;

                        if (!Storage.Songs.ContainsKey(name))
                        {
                            Song song = new Song(name, length);
                            Storage.Songs.Add(name, song);
                        }
                        Storage.Songs[name].OutYear = "";
                        Storage.Songs[name].Genre = "";
                        Storage.Songs[name].Duration = length;
                    }
                    else if (playlistRegex.IsMatch(line))
                    {
                        string name = playlistRegex.Match(line).Groups["playlistName"].Value;
                        string songs = playlistRegex.Match(line).Groups["songs"].Value.Replace("\'", "");

                        List<string> songsInput = songs.Split(", ").ToList<string>();

                        if (!Storage.Playlists.ContainsKey(name))
                        {
                            Playlist playlist = new Playlist(name);
                            Storage.Playlists.Add(name, playlist);
                        }
                        Storage.Playlists[name].Duration = "";

                        foreach (string songName in songsInput)
                        {
                            Storage.Playlists[name].Songs.Add(Storage.Songs[songName]);
                        }
                    }
                }
            }
        }
    }
}

