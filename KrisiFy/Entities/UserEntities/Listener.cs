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
        Playlist playlist;
        Dictionary<string, Playlist> playlistCollection;
        public Listener(string username, string password, string fullName, DateTime birthDate, List<string> genres, Playlist playlist, Dictionary<string, Playlist> playlistCollection) : base(username, password, fullName, birthDate, genres)
        {
            this.playlist = playlist;
            this.playlistCollection = playlistCollection;
        }

        public override void infoPrint()
        {
            base.infoPrint();
        }

        public override void playlistsPrint()
        {
            base.playlistsPrint();
        }

        public override void songsInPlaylistsAndLengthPrint()
        {
            base.songsInPlaylistsAndLengthPrint();
        }
    }
}
