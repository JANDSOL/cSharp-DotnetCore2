using System;

namespace CoreSchool.Entities
{
    public class Subject
    {
        private string uniqueId;
        public string UniqueId { get; private set; }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Subject() => UniqueId = Guid.NewGuid().ToString();
    }
}