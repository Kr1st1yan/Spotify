namespace KrisiFy.Entities.ContentEntities.InterfaceAndAbstractClasses
{
    public abstract class Content : IContentInterface
    {
        private string name;
        private string duration;
        protected Content(string name)
        {
            this.name = name;
        }
        protected Content(string name, string duration)
        {
            this.Name = name;
            this.Duration = duration;
        }
        public string Name { get => name; set => name = value; }
        public string Duration { get => duration; set => duration = value; }
    }
}
