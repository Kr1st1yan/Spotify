using KrisiFy.ReadAndWrite;
using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using KrisiFy.Entities.UserEntities;
using KrisiFy.Entities.ContentEntities;
using KrisiFy.DataStore;
using KrisiFy.Logging;
using KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses;
using KrisiFy.Displayers;

namespace KrisiFy
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            ReadFile readFile = new ReadFile();
            Displayer displayer = new Displayer();
            WriteOnFile writer = new WriteOnFile();
            readFile.read();

            Console.WriteLine("Welcome to KrisiFy!");
            Console.WriteLine();
            Console.WriteLine("Register [1]          Log in [2]");

            int validator = 0;

            while (validator == 0)
            {
                string input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    validator++;
                    logger.register(readFile);
                    int logg = 0;

                    Console.WriteLine("Do you want to log in?      Yes [1]      No [2]");

                    while (logg == 0)
                    {
                        string command = Console.ReadLine();
                        if (command.Equals("1"))
                        {
                            logg++;
                            displayer.loginsDisplay(readFile, logger, displayer);
                        }
                        else if (command.Equals("2"))
                        {
                            writer.write(readFile.Storage.returnAllStorageInfo());
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong command");
                        }
                    }
                }
                else if (input.Equals("2"))
                {
                    validator++;
                    displayer.loginsDisplay(readFile, logger, displayer);
                }
                else
                {
                    Console.WriteLine("Please press [1] or [2] only");
                }
            }
        }
    }
}






