using KrisiFy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses
{
    abstract class User : IUserInterface
    {
        private string username;
        private string password;
        private string fullName;
        private DateTime birthDate;
        private List<string> genres;
        protected User(string username, string password, string fullName, DateTime birthDate, List<string> genres)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.genres = genres;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public List<string> Genres { get => genres; set => genres = value; }

        virtual public void infoPrint() { }
        virtual public void playlistsPrint() { }
        virtual public void songsAndLengthPrint(string playlistName) { }
    }
}
