using System;
using System.Collections.Generic;
using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Util;
using static System.Console;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            WriteLine();

            var engine = new SchoolEngine();
            engine.Initialize();

            PrintCoursesSchool(engine.School);
        }

        private static void PrintCoursesSchool(School school)
        {
            Printer.WriteTitle($"Cursos de \"{school.Name}\"");
            if (school?.Courses != null)
            {
                foreach (var course in school.Courses)
                {
                    WriteLine($"Nombre: \"{course.Name}\", Id: \"{course.UniqueId}\"");
                }
            }
        }
    }
}
