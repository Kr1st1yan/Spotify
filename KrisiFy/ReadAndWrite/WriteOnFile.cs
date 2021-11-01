using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.ReadAndWriteFiles
{
    class WriteOnFile
    {
        private List<string> data = new List<string>();

        public List<string> Data { get => data; set => data = value; }

        /* public async Task write()
         {
             await File.WriteAllLinesAsync("E:\\Spotify\\KrisiFy\\ReadAndWriteFiles\\WriteFile.txt", data);
         }*/

        public async Task ExampleAsync(string input)
        {
            using StreamWriter file = new StreamWriter("E:\\Spotify\\Spotify\\KrisiFy\\ReadAndWriteFiles\\WriteFile.txt", append: true);
            await file.WriteLineAsync(input);
        }


    }
}
