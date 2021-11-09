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
        public async Task write(string input)
        {
            File.WriteAllText("E:\\Spotify\\Spotify\\KrisiFy\\ReadAndWrite\\ReadAndWriteFiles\\KrisiFy.txt", String.Empty);
            using StreamWriter file = new StreamWriter("E:\\Spotify\\Spotify\\KrisiFy\\ReadAndWrite\\ReadAndWriteFiles\\KrisiFy.txt", append: true);
            await file.WriteLineAsync(input);
        }
    }
}
