using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.DataStore
{
    class Storage
    {
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


        public string returnAllStorageInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Listener lis in listeners.Values)
            {
                sb.Append(String.Format("<user><{0}>({1}){{listener}}</user>\n", lis.Username, lis.Password));
            }

            foreach (Artist artist in artists.Values)
            {
                sb.Append(String.Format("<user><{0}>({1}){{artist}}</user>\n", artist.Username, artist.Password));
            }

            foreach (Listener lis in listeners.Values)
            {
                sb.Append(String.Format("<listener><{0}><{1}>[{2}](genres: [", lis.Username, lis.FullName, lis.BirthDate.ToString("dd/MM/yyyy")));

                if (lis.Genres.Count == 0)
                {
                    sb.Append("])(likedSongs: [");
                }
                else
                {
                    for (int i = 0; i < lis.Genres.Count; i++)
                    {
                        if (i == lis.Genres.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(likedSongs: [", lis.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", lis.Genres[i]));
                        }
                    }
                }

                if (lis.FavouriteSongs.Count == 0)
                {
                    sb.Append("])(playlists: [");
                }
                else
                {
                    for (int i = 0; i < lis.FavouriteSongs.Count; i++)
                    {
                        if (i == lis.FavouriteSongs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(playlists: [", lis.FavouriteSongs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", lis.FavouriteSongs[i].Name));
                        }
                    }

                }

                if (lis.PlaylistCollection.Count == 0)
                {
                    sb.Append("])</listener>\n");
                }
                else
                {

                    for (int i = 0; i < lis.PlaylistCollection.Count; i++)
                    {
                        if (i == lis.PlaylistCollection.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</listener>\n", lis.PlaylistCollection[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", lis.PlaylistCollection[i].Name));
                        }
                    }
                }



            }

            foreach (Artist art in artists.Values)
            {
                sb.Append(String.Format("<artist><{0}><{1}>[{2}](genres: [", art.Username, art.FullName, art.BirthDate.ToString("dd/MM/yyyy")));

                if (art.Genres.Count == 0)
                {
                    sb.Append("])(likedSongs: [");
                }
                else
                {
                    for (int i = 0; i < art.Genres.Count; i++)
                    {
                        if (i == art.Genres.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])(albums: [", art.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", art.Genres[i]));
                        }
                    }
                }

                if (art.Albums.Count == 0)
                {
                    sb.Append("])</artist>\n");
                }
                else
                {
                    for (int i = 0; i < art.Albums.Count; i++)
                    {
                        if (i == art.Albums.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</artist>\n", art.Albums[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", art.Albums[i].Name));
                        }
                    }
                }
            }

            foreach (Album alb in albums.Values)
            {
                sb.Append(String.Format("<album><{0}>[{1}](genres: [", alb.Name, alb.OutYear));

                if (alb.Genres.Count == 0)
                {
                    sb.Append("])(songs: [");
                }
                else
                {
                    for (int i = 0; i < alb.Genres.Count; i++)
                    {
                        if (i == alb.Genres.Count - 1)
                        {
                            sb.Append(String.Format("{0}])(songs: [", alb.Genres[i]));
                        }
                        else
                        {
                            sb.Append(String.Format("{0}, ", alb.Genres[i]));
                        }
                    }
                }

                if (alb.Songs.Count == 0)
                {
                    sb.Append("])</album>\n");
                }
                else
                {

                    for (int i = 0; i < alb.Songs.Count; i++)
                    {
                        if (i == alb.Songs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</album>\n", alb.Songs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", alb.Songs[i].Name));
                        }
                    }
                }
            }

            foreach (Song sng in songs.Values)
            {
                sb.Append(String.Format("<song><{0}>", sng.Name));

                if (sng.Duration == "")
                {
                    sb.Append("[]</song>\n");
                }
                else
                {
                    sb.Append(String.Format("[{0}]</song>\n", sng.Duration));
                }
            }

            foreach (Playlist pls in playlists.Values)
            {
                sb.Append(String.Format("<playlists><{0}>(songs: [", pls.Name));

                if (pls.Songs.Count == 0)
                {
                    sb.Append("])</playlists>");
                }
                else
                {
                    for (int i = 0; i < pls.Songs.Count; i++)
                    {
                        if (i == pls.Songs.Count - 1)
                        {
                            sb.Append(String.Format("\'{0}\'])</playlists>", pls.Songs[i].Name));
                        }
                        else
                        {
                            sb.Append(String.Format("\'{0}\', ", pls.Songs[i].Name));
                        }
                    }
                }
            }
            return sb.ToString();
        }
    }
}
