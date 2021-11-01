using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Interfaces
{
   public interface IUserInterface
    {
        void infoPrint();

        void playlistsPrint();

        void songsAndLengthPrint(string playlistName);

    }
}
