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
        public async Task Write(string input)
        {
            File.WriteAllText(Constants.PATH_TO_TEXT_FILE, String.Empty);
            using StreamWriter file = new StreamWriter(Constants.PATH_TO_TEXT_FILE, append: true);
            await file.WriteLineAsync(input);
        }
    }
}
