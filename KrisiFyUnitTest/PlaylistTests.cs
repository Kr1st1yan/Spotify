using System;
using System.Collections.Generic;
using System.Text;
using KrisiFy.Entities.ContentEntities;
using NUnit.Framework;

namespace KrisiFyUnitTest
{
   public class PlaylistTests
    {
        [Test]
        public void AddingSong_Sucessfully()
        {
            //Arrange
            Playlist playlist = new Playlist("pesni");
            Song song = new Song("pesen1");

            //Act
            playlist.AddSong(song);

            //Assert
            Assert.Contains(song, playlist.Songs);
        }

        [Test]
        public void AddingSong_AlreadyExists()
        {
            //Arrange
            Playlist playlist = new Playlist("pesni");
            Song song = new Song("pesen1");
            playlist.AddSong(song);
            List<Song> list = new List<Song>();
            list.Add(song);

            //Act
            playlist.AddSong(song);
            List<Song> list1 = playlist.Songs;

            //Assert
            Assert.AreEqual(list1.Count, list.Count);
        }


        [Test]
        public void RemoveSong_Sucessfully()
        {
            //Arrange
            Playlist playlist = new Playlist("pesni");
            Song song = new Song("pesen1");
            playlist.AddSong(song);

            //Act 
            playlist.RemoveSong(song);

            //Assert
            Assert.AreEqual(playlist.Songs.Count, 0);
        }

        [Test]
        public void CalculatingPlaylistTime_Sucessfully()
        {
            //Arrange
            StringBuilder sb = new StringBuilder();

            Playlist playlist = new Playlist("pesni");
            Playlist playlist1 = new Playlist("pesni1");

            Song song = new Song("pesen1");
            song.Duration = "00:12:22";
            Song song1 = new Song("pesen2");
            song1.Duration = "01:10:05";

            playlist.AddSong(song);
            playlist.AddSong(song1);

            sb.Append(String.Format("The songs in the playlist are:\n"));
            sb.Append(String.Format("    {0}. {1}\n", 1, song.Name));
            sb.Append(String.Format("    {0}. {1}\n", 2, song1.Name));
            sb.Append("Playlist length is: 01:22:27\n");

            //Act
            string result = playlist1.CalculatePlaylistTime(playlist);
          
            //Assert
            Assert.AreEqual(sb.ToString(), result);
        }
    }
}
