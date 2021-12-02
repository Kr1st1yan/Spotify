using System;
using System.Collections.Generic;
using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using NUnit.Framework;

namespace KrisiFyUnitTest
{
    public class ArtistTests
    {

        const string albumNameSet = "albumNomer1";

        [Test]
        public void CreateAlbum_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");

            //Act
            Album album = artist.createAlbum(albumNameSet);

            //Assert
            Assert.AreEqual(album.Name, albumNameSet);
        }

        [Test]
        public void CreateAlbum_Fail()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");

            //Act
            Album album = artist.createAlbum(albumNameSet);
            artist.Albums.Add(album);
            Album albumToCheck = artist.createAlbum(albumNameSet);

            //Assert
            Assert.AreEqual(albumToCheck, null);
        }

        [Test]
        public void DeleteAlbum_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");

            //Act
            Album album = artist.createAlbum(albumNameSet);
            artist.Albums.Add(album);
            artist.deleteAlbum(albumNameSet);

            //Assert
            Assert.AreEqual(artist.Albums.Count, 0);
        }

        [Test]
        public void DeleteAlbum_Fail()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");

            //Act
            Album album = artist.createAlbum(albumNameSet);
            artist.Albums.Add(album);
            artist.deleteAlbum("albumNomer2");

            //Assert
            Assert.AreEqual(artist.Albums.Count, 1);
        }

        [Test]
        public void RemoveSong_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");
            Song song = new Song("purvi");

            Album album = artist.createAlbum(albumNameSet);
            artist.Albums.Add(album);
            artist.Albums[0].Songs.Add(song);

            //Act
            artist.removeSongsFormAlbum(song, albumNameSet);

            //Assert
            Assert.AreEqual(artist.Albums[0].Songs.Count, 0);
        }

        [Test]
        public void AddSong_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            List<Album> albums = new List<Album>();
            Artist artist = new Artist("az", "123", "azaz", DateTime.MinValue, genres, albums, "artist");
            Song song = new Song("purvi");

            Album album = artist.createAlbum(albumNameSet);
            artist.Albums.Add(album);

            //Act
            artist.addSongsToAlbum(song, albumNameSet);

            //Assert
            Assert.AreEqual(artist.Albums[0].Songs.Count, 1);
        }
    }
}
