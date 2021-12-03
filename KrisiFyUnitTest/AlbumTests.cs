using NUnit.Framework;
using KrisiFy.Entities.ContentEntities;
using System.Collections.Generic;

namespace KrisiFyUnitTest
{
    public class AlbumTests
    {
        [Test]
        public void AddingSong_Sucessfully()
        {
            //Arrange
            Album album = new Album("pesni");
            Song song = new Song("pesen1");

            //Act
            album.AddSong(song);

            //Assert
            Assert.Contains(song, album.Songs);
        }

        [Test]
        public void AddingSong_AlreadyExists()
        {
            //Arrange
            Album album = new Album("pesni");
            Song song = new Song("pesen1");
            album.AddSong(song);
            List<Song> list = new List<Song>();
            list.Add(song);

            //Act
            album.AddSong(song);
            List<Song> listToCheck = album.Songs;

            //Assert
            Assert.AreEqual(listToCheck.Count, list.Count);
        }

        [Test]
        public void RemoveSong_Sucessfully()
        {
            //Arrange
            Album album = new Album("pesni");
            Song song = new Song("pesen1");
            album.AddSong(song);

            //Act 
            album.RemoveSong(song);

            //Assert
            Assert.AreEqual(album.Songs.Count, 0);
        }
    }
}