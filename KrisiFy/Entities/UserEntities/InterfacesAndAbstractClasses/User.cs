using KrisiFy.Interfaces;
using KrisiFy.ReadAndWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.UserEntities.InterfacesAndAbstractClasses
{
    public abstract class User : IUserInterface
    {
        private string username;
        private string password;
        private string fullName;
        private DateTime birthDate;
        private List<string> genres;
        private string type;
        protected User(string username, string password, string fullName, DateTime birthDate, List<string> genres, string type)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.genres = genres;
            this.Type = type;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public List<string> Genres { get => genres; set => genres = value; }
        public string Type { get => type; set => type = value; }

        virtual public void InfoPrint() { }
        virtual public void PlaylistsPrint() { }
        virtual public void SongsAndLengthPrint(string playlistName) {
        }
    }
}
