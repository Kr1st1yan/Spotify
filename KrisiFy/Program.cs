using KrisiFy.ReadAndWrite;
using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using KrisiFy.Entities.UserEntities;
using KrisiFy.Entities.ContentEntities;

namespace KrisiFy
{
    class Program
    {

        //Currently here are only test parameters
        static void Main(string[] args)
        {

            List<Album> albums = new List<Album>();
            List<Song> songs = new List<Song>();

            List<string> genres = new List<string>();
            genres.Add("rap");
            genres.Add("rock");
            genres.Add("metal");
            genres.Add("folk");           
            
            List<Playlist> playlists = new List<Playlist>();
            Playlist playlist = new Playlist("edin");
            Playlist playlist2 = new Playlist("vtori");
            Playlist playlist3 = new Playlist("treti");
            /*playlists.Add(playlist);
            playlists.Add(playlist2);
            playlists.Add(playlist3);*/

            Artist artist = new Artist("goshko", "afdafadf", "gosho p", DateTime.Now, genres, albums);
            Album album = new Album("albumnomer1", "11:20", songs, artist, "chalga", DateTime.Now);

            
            Song song = new Song("jiv", "1:30:00",album,artist,"chalga",DateTime.Now);
            Song song1 = new Song("ne", "8:04:20",album,artist,"chalga",DateTime.Now);
            Song song2 = new Song("asfagad", "4:30",album,artist,"chalga",DateTime.Now);

            /*songs.Add(song);
            songs.Add(song1);
            songs.Add(song2);
*/
            List<Song> songsToRemove = new List<Song>();

            Listener listener = new Listener("bobi", "afadfaf", "bobi chepinci", DateTime.Now, genres, songs, playlists);
            listener.FavouriteSongs.Add(song);
            listener.FavouriteSongs.Add(song1);
            listener.PlaylistCollection.Add(playlist);
            listener.PlaylistCollection.Add(playlist2);

            /*listener.infoPrint();
            listener.favouriteSongsPrint();*/
           /* listener.playlistsPrint();*/
            playlist.Songs.Add(song);
            playlist.Songs.Add(song1);
            /*listener.playlistsPrint();*/


            /*playlist.Songs.Add(song);
            playlist.Songs.Add(song1);*/

            songsToRemove.Add(song1);
            songsToRemove.Add(song2);
            songsToRemove.Add(song);

            /*listener.songsAndLengthPrint("vtori");*/
            /*listener.createPlaylist("vtori");*/
            /*listener.removeSongFromFavourites(songsToRemove);*/
            /*listener.addSongsToFavourites(songsToRemove);*/
            /*listener.removeSongsFromPlaylist(songsToRemove, "vtori");*/


            //Playlist time is not stored
            //Playlist time calculation should be refacdtored

            artist.Albums.Add(album);

            /*artist.infoPrint();*/
            artist.songsAndLengthPrint("albumnomer1");
            artist.playlistsPrint();
            artist.addSongsToAlbum(songsToRemove, "albumnomer1");
            /*artist.deleteAlbum("albumnomer2");
            artist.createAlbum("albumnomer1");
            artist.createAlbum("albumnomer2");*/



        }

    }
}

