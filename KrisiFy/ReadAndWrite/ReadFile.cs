using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KrisiFy.ReadAndWrite
{
    class ReadFile
    {

        public void read()
        {
            /*StreamReader reader = new StreamReader("E:\\Spotify\\KrisiFy\\ReadAndWriteFiles\\KrisiFy.txt");*/
            /*Regex userRegex = new Regex("(?<=<user>)(?<username><[A-Z][a-z0-9]+>)(?<password>\\(.+\\))(?<type>{[a-z]+\\})(?=</user>)");*/
            Regex userRegex = new Regex("(?<=<user>)<(?<username>[A-Z][a-z0-9]+)>\\((?<password>.+)\\){(?<type>[a-z]+)}(?=<\\/user>)");
            /* Regex songRegex = new Regex("(?<=<song>)<(?<name>.+)>(?<length>[[0-9]{1,}:[0-9]{2}])(?=<\\/song)");*/
            Regex songRegex = new Regex("(?<=<song>)<(?<name>.+)>\\[(?<length>[0-9]{1,}:[0-9]{2})\\](?=<\\/song)");
            /*Regex listenRegex = new Regex("(?<=<listener>)<(?<username>[A-Z][a-z0-9]+)><(?<FullName>[A-Z][a-z]+ [A-Z][a-z]+|[A-Z][a-z]+ [A-Z])>\\[(?<dateOfBirth>[0-9]{2}\\/[0-9]{2}\\/[0-9]{4})\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(likedSongs: \\[(?<likedSongs>.*?)\\]\\)\\(playlists: \\[(?<playlists>.*?)\\]\\)(?=<\\/listener>)");*/
            Regex listenerRegex = new Regex("(?<=<listener>)<(?<username>\\S+)><(?<fullName>\\D+)>\\[(?<dateOfBirth>\\d+\\/\\d+\\/\\d+)\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(likedSongs: \\[(?<likedSongs>.*?)\\]\\)\\(playlists: \\[(?<playlists>.*?)\\]\\)(?=<\\/listener>)");
            Regex artistRegex = new Regex("(?<=<artist>)<(?<artistName>\\S+)><(?<fullName>\\D+ [A-Z][a-z]+|[A-Z][a-z]+)>\\[(?<dateOfBirth>\\d+\\/\\d+\\/\\d+)\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(albums: \\[(?<albums>.*?)\\]\\)(?=<\\/artist>)");
            Regex albumRegex = new Regex("(?<=<album>)<(?<albumName>.*?)>\\[(?<year>\\d{4})\\]\\(genres: \\[(?<genres>.*?)\\]\\)\\(songs: \\[(?<songs>.*?)\\]\\)(?=<\\/album>)");

            WriteOnFile writer = new WriteOnFile();

            foreach (string line in System.IO.File.ReadLines("E:\\Spotify\\KrisiFy\\ReadAndWriteFiles\\KrisiFy.txt"))
            {
                if (line != null)
                {
                    if (userRegex.IsMatch(line))
                    {
                        string username = userRegex.Match(line).Groups["username"].Value;
                        string password = userRegex.Match(line).Groups["password"].Value;
                        string type = userRegex.Match(line).Groups["type"].Value;

                        string output = String.Format("Name is: {0}, password is: {1}\nType is {2}\n", username, password, type);

                        writer.ExampleAsync(output);

                        Console.WriteLine(username);
                        Console.WriteLine(password);
                        Console.WriteLine(type);
                        Console.WriteLine();
                    }
                    else if (songRegex.IsMatch(line))
                    {
                        string name = songRegex.Match(line).Groups["name"].Value;
                        string length = songRegex.Match(line).Groups["length"].Value;

                        writer.ExampleAsync(name);

                        Console.WriteLine(name);
                        Console.WriteLine(length);
                        Console.WriteLine();
                    }
                    else if (listenerRegex.IsMatch(line))
                    {
                        string username = listenerRegex.Match(line).Groups["username"].Value;
                        string fullName = listenerRegex.Match(line).Groups["fullName"].Value;
                        string dateOfBirth = listenerRegex.Match(line).Groups["dateOfBirth"].Value;
                        string genres = listenerRegex.Match(line).Groups["genres"].Value.Replace('\'','\"');
                        string likedSongs = listenerRegex.Match(line).Groups["likedSongs"].Value.Replace('\'','\"');
                        string playlists = listenerRegex.Match(line).Groups["playlists"].Value.Replace('\'','\"');
                        /* string b = Regex.Replace(a, @"[^0-9a-zA-Z: ,]+", " ");*/
                        writer.ExampleAsync(username);
                        Console.WriteLine(username);
                        Console.WriteLine(fullName);
                        Console.WriteLine(dateOfBirth);
                        Console.WriteLine(genres);
                        Console.WriteLine(likedSongs);
                        Console.WriteLine(playlists);
                        Console.WriteLine();
                    }
                    else if (artistRegex.IsMatch(line))
                    {
                        string name = artistRegex.Match(line).Groups["artistName"].Value;
                        string fullName = artistRegex.Match(line).Groups["fullName"].Value;
                        string dateOfBirth = artistRegex.Match(line).Groups["dateOfBirth"].Value;
                        string genres = artistRegex.Match(line).Groups["genres"].Value.Replace('\'', '\"');
                        string albums = artistRegex.Match(line).Groups["albums"].Value.Replace('\'', '\"');
                        writer.ExampleAsync(name);
                        Console.WriteLine(name);
                        Console.WriteLine(fullName);
                        Console.WriteLine(dateOfBirth);
                        Console.WriteLine(genres);
                        Console.WriteLine(albums);
                        Console.WriteLine();
                    }
                    else if (albumRegex.IsMatch(line))
                    {
                        string name = albumRegex.Match(line).Groups["albumName"].Value;
                        string year = albumRegex.Match(line).Groups["year"].Value;
                        string genres = albumRegex.Match(line).Groups["genres"].Value.Replace('\'', '\"');
                        string songs = albumRegex.Match(line).Groups["songs"].Value.Replace('\'', '\"');
                        writer.ExampleAsync(name);
                        Console.WriteLine(name);
                        Console.WriteLine(year);                    
                        Console.WriteLine(genres);
                        Console.WriteLine(songs);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
