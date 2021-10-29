using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisiFy.Entities.ContentEntities.InterfaceAndAbstractClasses
{
    abstract class Content : IContentInterface
    {
        private string name;
        private DateTime duration;

        protected Content(string name, DateTime duration)
        {
            this.Name = name;
            this.Duration = duration;
        }

        public DateTime Duration { get => duration; set => duration = value; }
        public string Name { get => name; set => name = value; }
    }
}
