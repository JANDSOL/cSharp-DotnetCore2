using System;

namespace CoreSchool.Entities
{
    class School
    {
        string name;
        public string Name
        {
            get { return name; }
            set { name = value.ToUpper(); }
        }

        int foundationAge;
        public int FoundationAge
        {
            get { return foundationAge; }
            set { foundationAge = value; }
        }

        string country;
        public string Country {
            get { return country; }
            set { country = value; }
        }

        string city;
        public string City {
            get { return city; }
            set { city = value; }
        }

        TypesSchool typesSchool;
        public TypesSchool TypesSchool { get; set; }

        private Courses[] courses;
        public Courses[] Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public School(string name, int foundationAge) => (this.name, this.foundationAge) = (name, foundationAge);

        public School(
            string name,
            int foundationAge,
            TypesSchool typesSchool,
            string country="",
            string city="")
        {
            (this.name, this.foundationAge) = (name, foundationAge);
            this.country = country;
            this.city = city;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Name}\", Tipo: \"{TypesSchool}\"{System.Environment.NewLine}País: \"{Country}\", Ciudad: \"{City}\"";
        }
    }
}
