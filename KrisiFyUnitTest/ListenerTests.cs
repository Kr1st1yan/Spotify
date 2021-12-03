using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace KrisiFyUnitTest
{
    public class ListenerTests
    {
        [Test]
        public void CreatePlaylist_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Playlist playlist = listener.CreatePlaylist("playlist1");

            //Assert
            Assert.AreEqual(playlist.Name, "playlist1");
        }

        [Test]
        public void CreatePlaylist_Fail()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Playlist playlist = listener.CreatePlaylist("playlist1");
            listener.PlaylistCollection.Add(playlist);

            //Assert
            Assert.AreEqual(listener.CreatePlaylist("playlist1"), null);
        }

        [Test]
        public void RemovePlaylist_Sucessfullly()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Playlist playlist = listener.CreatePlaylist("playlist1");
            listener.PlaylistCollection.Add(playlist);
            listener.RemovePlaylist("playlist1");

            //Assert
            Assert.AreEqual(listener.PlaylistCollection.Count, 0);
        }

        [Test]
        public void RemovePlaylist_Fail()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Playlist playlist = listener.CreatePlaylist("playlist1");
            listener.PlaylistCollection.Add(playlist);
            listener.RemovePlaylist("pls");

            //Assert
            Assert.AreEqual(listener.PlaylistCollection.Count, 1);
        }

        [Test]
        public void AddSongToFavourites_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Song song = new Song("dqlkambqlo");
            listener.AddSongsToFavourites(song);

            //Assert
            Assert.AreEqual(listener.FavouriteSongs.Songs.Count, 1);
        }

        [Test]
        public void AddSongToFavourites_Fail()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Song song = new Song("dqlkambqlo");
            listener.AddSongsToFavourites(song);
            listener.AddSongsToFavourites(song);

            //Assert
            Assert.AreEqual(listener.FavouriteSongs.Songs.Count, 1);
        }


        [Test]
        public void RemoveSongFromFavourites_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            List<Playlist> collection = new List<Playlist>();
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Song song = new Song("dqlkambqlo");
            listener.AddSongsToFavourites(song);
            listener.RemoveSongFromFavourites(song);

            //Assert
            Assert.AreEqual(listener.FavouriteSongs.Songs.Count, 0);
        }

        [Test]
        public void AddSongToPlaylist_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            Playlist playlist = new Playlist("jiv");
            List<Playlist> collection = new List<Playlist>();
            collection.Add(playlist);
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Song song = new Song("dqlkambqlo");
            listener.AddSongsToPlaylist(song, "jiv");

            //Assert
            Assert.AreEqual(listener.PlaylistCollection[0].Songs.Count, 1);
        }

        [Test]
        public void RemoveSongFromPlaylist_Sucessfully()
        {
            //Arrange
            List<string> genres = new List<string>();
            Playlist favourites = new Playlist("favs");
            Playlist playlist = new Playlist("jiv");
            List<Playlist> collection = new List<Playlist>();
            collection.Add(playlist);
            Listener listener = new Listener("az", "123", "adf", DateTime.MinValue, genres, favourites, collection, "listener");

            //Act
            Song song = new Song("dqlkambqlo");
            listener.AddSongsToPlaylist(song, "jiv");
            listener.RemoveSongsFromPlaylist(song, "jiv");

            //Assert
            Assert.AreEqual(listener.PlaylistCollection[0].Songs.Count, 0);
        }
    }
}
