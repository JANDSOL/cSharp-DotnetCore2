using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Util;
using static System.Console;
using System.Linq;

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
            var listObjects = engine.GetSchoolObjects();

            var listIntAddress = from obj in listObjects
                                 where obj is Student
                                 select (Student)obj;

            // engine.School.ClearSpace();
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
