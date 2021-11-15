using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.DataStore
{
    class Storage
    {
        Dictionary<string, User> users = new Dictionary<string, User>();
        Dictionary<string, Listener> listeners = new Dictionary<string, Listener>();
        Dictionary<string, Artist> artists = new Dictionary<string, Artist>();
        Dictionary<string, Album> albums = new Dictionary<string, Album>();
        Dictionary<string, Song> songs = new Dictionary<string, Song>();
        Dictionary<string, Playlist> playlists = new Dictionary<string, Playlist>();

        public Storage()
        {
        }

        public Dictionary<string, Listener> Listeners { get => listeners; set => listeners = value; }
        public Dictionary<string, Artist> Artists { get => artists; set => artists = value; }
        public Dictionary<string, Album> Albums { get => albums; set => albums = value; }
        public Dictionary<string, Song> Songs { get => songs; set => songs = value; }
        public Dictionary<string, Playlist> Playlists { get => playlists; set => playlists = value; }
        public Dictionary<string, User> Users { get => users; set => users = value; }

        public string returnAllStorageInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(returnUserInfo());
            sb.Append(returnListenerInfo());
            sb.Append(returnArtistInfo());
            sb.Append(returnAlbumInfo());
            sb.Append(returnSongInfo());
            sb.Append(returnPlaylistInfo());

            return sb.ToString();
        }

        public string returnUserInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Listener listener in listeners.Values)
            {
                sb.Append(String.Format("<user><{0}>({1}){{listener}}</user>\n", listener.Username, listener.Password));
            }

            foreach (Artist artist in artists.Values)
            {
                sb.Append(String.Format("<user><{0}>({1}){{artist}}</user>\n", artist.Username, artist.Password));
            }

            return sb.ToString();
        }

        public string returnListenerInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Listener listener in listeners.Values)
            {
                sb.Append(String.Format("<listener><{0}><{1}>[{2}](genres: [", listener.Username, listener.FullName, listener.BirthDate.ToString("dd/MM/yyyy")));

                if (listener.Genres.Count == 0)
                {
                    sb.Append("])(likedSongs: [");
                }
                else
                {
                    for (int i = 0; i < listener.Genres.Count; i++)
                    {
                        if (i == listener.Genres.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(likedSongs: [", listener.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", listener.Genres[i]));
                        }
                    }
                }

                if (listener.FavouriteSongs.Songs.Count == 0)
                {
                    sb.Append("])(playlists: [");
                }
                else
                {
                    for (int i = 0; i < listener.FavouriteSongs.Songs.Count; i++)
                    {
                        if (i == listener.FavouriteSongs.Songs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(playlists: [", listener.FavouriteSongs.Songs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", listener.FavouriteSongs.Songs[i].Name));
                        }
                    }
                }

                if (listener.PlaylistCollection.Count == 0)
                {
                    sb.Append("])</listener>\n");
                }
                else
                {
                    for (int i = 0; i < listener.PlaylistCollection.Count; i++)
                    {
                        if (i == listener.PlaylistCollection.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</listener>\n", listener.PlaylistCollection[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", listener.PlaylistCollection[i].Name));
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public string returnArtistInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Artist artist in artists.Values)
            {
                sb.Append(String.Format("<artist><{0}><{1}>[{2}](genres: [", artist.Username, artist.FullName, artist.BirthDate.ToString("dd/MM/yyyy")));

                if (artist.Genres.Count == 0)
                {
                    sb.Append("])(likedSongs: [");
                }
                else
                {
                    for (int i = 0; i < artist.Genres.Count; i++)
                    {
                        if (i == artist.Genres.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(albums: [", artist.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", artist.Genres[i]));
                        }
                    }
                }

                if (artist.Albums.Count == 0)
                {
                    sb.Append("])</artist>\n");
                }
                else
                {
                    for (int i = 0; i < artist.Albums.Count; i++)
                    {
                        if (i == artist.Albums.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</artist>\n", artist.Albums[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", artist.Albums[i].Name));
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public string returnAlbumInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Album album in albums.Values)
            {
                sb.Append(String.Format("<album><{0}>[{1}](genres: [", album.Name, album.OutYear));

                if (album.Genres.Count == 0)
                {
                    sb.Append("])(songs: [");
                }
                else
                {
                    for (int i = 0; i < album.Genres.Count; i++)
                    {
                        if (i == album.Genres.Count - 1)
                        {
                            sb.Append(String.Format("{0}])(songs: [", album.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("{0}, ", album.Genres[i]));
                        }
                    }
                }

                if (album.Songs.Count == 0)
                {
                    sb.Append("])</album>\n");
                }
                else
                {
                    for (int i = 0; i < album.Songs.Count; i++)
                    {
                        if (i == album.Songs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</album>\n", album.Songs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", album.Songs[i].Name));
                        }
                    }
                }
            }
            return sb.ToString();
        }

        public string returnSongInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Song song in songs.Values)
            {
                sb.Append(String.Format("<song><{0}>", song.Name));

                if (song.Duration == "")
                {
                    sb.Append("[]</song>\n");
                }
                else
                {
                    sb.Append(String.Format("[{0}]</song>\n", song.Duration));
                }
            }
            return sb.ToString();
        }

        public string returnPlaylistInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Playlist playlist in playlists.Values)
            {
                sb.Append(String.Format("<playlists><{0}>(songs: [", playlist.Name));

                if (playlist.Songs.Count == 0)
                {
                    sb.Append("])</playlists>");
                }
                else
                {
                    for (int i = 0; i < playlist.Songs.Count; i++)
                    {
                        if (i == playlist.Songs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</playlists>", playlist.Songs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", playlist.Songs[i].Name));
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
