using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class School : BaseSchoolObject
    {
        public int FoundationAge { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public TypesSchool TypesSchool { get; set; }
        public List<Course> Courses { get; set; }

        public School(string name, int foundationAge) => (Name, FoundationAge) = (name, foundationAge);

        public School(
            string name,
            int foundationAge,
            TypesSchool typesSchool,
            string country = "",
            string city = "")
        {
            (Name, FoundationAge) = (name, foundationAge);
            this.Country = country;
            this.City = city;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Name}\", Tipo: \"{TypesSchool}\"{System.Environment.NewLine}País: \"{Country}\", Ciudad: \"{City}\"";
        }
    }
}
