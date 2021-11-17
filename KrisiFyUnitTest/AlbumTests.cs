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
            album.addSong(album.Name, song);

            //Assert
            Assert.Contains(song, album.Songs);
        }

        [Test]
        public void AddingSong_AlreadyExists()
        {
            //Arrange
            Album album = new Album("pesni");
            Song song = new Song("pesen1");
            album.addSong(album.Name, song);
            List<Song> list = new List<Song>();
            list.Add(song);

            //Act
            album.addSong(album.Name, song);
            List<Song> list1 = album.Songs;

            //Assert
            Assert.AreEqual(list1.Count, list.Count);
        }

        [Test]
        public void RemoveSong_Sucessfully()
        {
            //Arrange
            Album album = new Album("pesni");
            Song song = new Song("pesen1");
            album.addSong(album.Name, song);

            //Act 
            album.removeSong(album.Name, song);

            //Assert
            Assert.AreEqual(album.Songs.Count, 0);
        }
    }
}