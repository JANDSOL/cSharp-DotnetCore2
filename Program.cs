using System;
using System.Collections.Generic;
using CoreSchool.Entities;
using static System.Console;

namespace StageOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var School = new School("Juan's School", 2022, TypesSchool.Primaria,
                                    country: "Ecuador", city: "Quito");
            School.Courses = new List<Courses>(){
                new Courses() { Name = "101", WorkingDay = TypesWorkingDay.Mañana },
                new Courses() { Name = "201", WorkingDay = TypesWorkingDay.Mañana },
                new Courses() { Name = "301", WorkingDay = TypesWorkingDay.Mañana },
            };
            School.Courses.Add(new Courses { Name = "102", WorkingDay = TypesWorkingDay.Tarde });
            School.Courses.Add(new Courses { Name = "202", WorkingDay = TypesWorkingDay.Tarde });
            var otherCollectionCourse = new List<Courses>(){
                new Courses() { Name = "401", WorkingDay = TypesWorkingDay.Mañana },
                new Courses() { Name = "501", WorkingDay = TypesWorkingDay.Mañana },
                new Courses() { Name = "501", WorkingDay = TypesWorkingDay.Tarde },
            };
            School.Courses.AddRange(otherCollectionCourse);
            PrintCoursesSchool(School);
            School.Courses.RemoveAll(delegate (Courses cou)
                {
                    return cou.Name == "301";
                });
            School.Courses.RemoveAll(cou => cou.Name == "501" && cou.WorkingDay == TypesWorkingDay.Mañana);

            WriteLine();
            PrintCoursesSchool(School);
        }

        private static bool RemoveCollection(Courses couObj)
        {
            return couObj.Name == "301";
        }

        private static void PrintCoursesSchool(School School)
        {
            WriteLine(new string('=', 60));
            WriteLine($"Cursos de \"{School.Name}\"");
            WriteLine(new string('=', 60));
            if (School?.Courses != null)
            {
                foreach (var course in School.Courses)
                {
                    WriteLine($"Nombre: \"{course.Name}\", Id: \"{course.UniqueId}\"");
                }
            }
        }

        private static void PrintCoursesForEach(Courses[] arrayCourses)
        {
            foreach (var course in arrayCourses)
            {
                WriteLine($"Nombre: \"{course.Name}\", Id: \"{course.UniqueId}\"");
            }
        }

        private static void PrintCoursesFor(Courses[] arrayCourses)
        {
            for (int i = 0; i < arrayCourses.Length; i++)
            {
                WriteLine($"Nombre: \"{arrayCourses[i].Name}\", Id: \"{arrayCourses[i].UniqueId}\"");
            }
        }

        private static void PrintCoursesDoWhile(Courses[] arrayCourses)
        {
            int counter = 0;
            do
            {
                WriteLine($"Nombre: \"{arrayCourses[counter].Name}\", Id: \"{arrayCourses[counter].UniqueId}\"");
                counter++;
            } while (counter < arrayCourses.Length);
        }

        private static void PrintCoursesWhile(Courses[] arrayCourses)
        {
            int counter = 0;
            while (counter < arrayCourses.Length)
            {
                WriteLine($"Nombre: \"{arrayCourses[counter].Name}\", Id: \"{arrayCourses[counter].UniqueId}\"");
                counter++;
            }
        }
    }
}
