﻿using KrisiFy.Entities.ContentEntities.InterfaceAndAbstractClasses;
using KrisiFy.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.ContentEntities
{
    class Song : Content
    {
        private Album album;
        private Artist artist;
        private string genre;
        private string outYear;

        public Song(string name) : base(name)
        {

        }
        public Song(string name, string duration) : base(name, duration)
        {

        }
        public Song(string name, string duration, Album album, Artist artist, string genre, string outYear) : base(name, duration)
        {
            this.Album = album;
            this.Artist = artist;
            this.Genre = genre;
            this.OutYear = outYear;
        }

        public string Genre { get => genre; set => genre = value; }
        public Album Album { get => album; set => album = value; }
        public Artist Artist { get => artist; set => artist = value; }
        public string OutYear { get => outYear; set => outYear = value; }
    }
}
