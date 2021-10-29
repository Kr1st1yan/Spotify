using KrisiFy.ReadAndWrite;
using KrisiFy.ReadAndWriteFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace KrisiFy
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile readFile = new ReadFile();
            readFile.read();


            String a = Console.ReadLine();
            Console.WriteLine(a);

        }

    }
}

