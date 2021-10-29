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
        private HashSet<Song> songs = new HashSet<Song>();

        public Playlist(string name, DateTime duration, HashSet<Song> songs) : base(name, duration)
        {
            this.songs = songs;
        }

        internal HashSet<Song> Songs { get => songs; set => songs = value; }
    }
}
