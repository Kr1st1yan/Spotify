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
        private HashSet<Album> albums;
        public Artist(string username, string password, string fullName, DateTime birthDate, List<string> genres, HashSet<Album> albums) : base(username, password, fullName, birthDate, genres)
        {
            this.Albums = albums;
        }

        internal HashSet<Album> Albums { get => albums; set => albums = value; }

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
