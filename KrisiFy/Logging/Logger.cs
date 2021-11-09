using KrisiFy.Entities.ContentEntities;
using KrisiFy.Entities.UserEntities;
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
        public void register(ReadFile readFile)
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
                        Artist artist = new Artist(username, password, fullName, DateTime.Parse(birthDate), genres, albums);
                        readFile.Storage.Artists.Add(username, artist);
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
                        List<Song> songs = new List<Song>();
                        List<Playlist> playlists = new List<Playlist>();
                        Listener listener = new Listener(username, password, fullName, DateTime.Parse(birthDate), genres, songs, playlists);
                        readFile.Storage.Listeners.Add(username, listener);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect role, please start your registration from the beggining!");
                }
            }
        }

        public Listener listenerLogin(ReadFile readFile, string username, string password, string role)
        {
            if (readFile.Storage.Listeners.ContainsKey(username))
            {
                if (password.Equals(readFile.Storage.Listeners[username].Password))
                {
                    return readFile.Storage.Listeners[username];
                }
                else
                {
                    Console.WriteLine("Wrong password!");
                }
            }
            else
            {
                Console.WriteLine("No user found!");
            }
            return null;
        }

        public Artist artistLogin(ReadFile readFile, string username, string password, string role)
        {
            if (readFile.Storage.Artists.ContainsKey(username))
            {
                if (password.Equals(readFile.Storage.Artists[username].Password))
                {
                    return readFile.Storage.Artists[username];
                }
                else
                {
                    Console.WriteLine("Wrong password!");
                }
            }
            else
            {
                Console.WriteLine("No user found!");
            }
            return null;
        }
    }
}
