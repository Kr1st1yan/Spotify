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

        internal List<Song> Songs { get => songs; set => songs = value; }
    }
}
