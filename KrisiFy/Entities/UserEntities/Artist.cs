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

        internal List<Album> Albums { get => albums; set => albums = value; }

        public override void infoPrint()
        {
            base.infoPrint();
        }

        public override void playlistsPrint()
        {
            base.playlistsPrint();
        }

        public override void songsAndLengthPrint(string playlistName)
        {
            base.songsAndLengthPrint(playlistName);
        }
    }
}
