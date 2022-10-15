using System;
using CoreSchool.Entities;

namespace StageOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var School = new School("Juan's School", 2022, TypesSchool.Primary,
                                    country: "Ecuador", city: "Quito");
            // School.TypeSchool = TypesSchool.Primary;
            Console.WriteLine(School);
        }
    }
}
