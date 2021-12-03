using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using KrisiFy.ReadAndWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Logging
{
    class Logger
    { 
        public void Register(ReadFile readFile)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Enter your full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter your birth date in format dd/MM/yyyy: ");
            string birthDate = Console.ReadLine();

            if (username == "" || password == "" || birthDate == "")
            {
                Console.WriteLine("One of the current fields is empty:");
                Console.WriteLine("1.Password");
                Console.WriteLine("1.Birth Date");
                Console.WriteLine("You should start your registration from the beggining!");
            }
            else
            {
                Console.WriteLine("Please select your role: [1] Artist     [2] Listener");
                string role = Console.ReadLine();

                if (role.Equals("1"))
                {
                    if (readFile.Storage.Artists.ContainsKey(username))
                    {
                        Console.WriteLine("Artist with this username already exists!");
                    }
                    else
                    {
                        List<string> genres = new List<string>();
                        List<Album> albums = new List<Album>();
                        Artist artist = new Artist(username, password, fullName, DateTime.Parse(birthDate), genres, albums, "artist");
                        readFile.Storage.Artists.Add(username, artist);
                        readFile.Storage.Users.Add(username, artist);
                    }
                }
                else if (role.Equals("2"))
                {
                    if (readFile.Storage.Listeners.ContainsKey(username))
                    {
                        Console.WriteLine("Listener with this username already exists!");
                    }
                    else
                    {
                        List<string> genres = new List<string>();
                        Playlist songs = new Playlist("");
                        List<Playlist> playlists = new List<Playlist>();
                        Listener listener = new Listener(username, password, fullName, DateTime.Parse(birthDate), genres, songs, playlists, "listener");
                        readFile.Storage.Listeners.Add(username, listener);
                        readFile.Storage.Users.Add(username, listener);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect role, please start your registration from the beggining!");
                }
            }
        }

        public bool Login(ReadFile readFile, string username, string password)
        {
            if (readFile.Storage.Users.ContainsKey(username))
            {
                if (password.Equals(readFile.Storage.Users[username].Password))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetUserType(ReadFile readFile, string username)
        {
            return readFile.Storage.Users[username].Type;
        }
    }
}
