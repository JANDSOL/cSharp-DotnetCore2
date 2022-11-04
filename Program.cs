using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Util;
using static System.Console;
using System.Collections.Generic;
using System;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += EventAction;

            var engine = new SchoolEngine();
            engine.Initialize();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            WriteLine();

            var reporter = new Reporter(engine.GetDictionaryObjects());
            var stuTesList = reporter.GetStudentTestsList();
            var sbjList = reporter.GetSubjectsList();
            var studentTestDicBySubject = reporter.GetStudentTestDicBySubject();
            var studentAverageBySubject = reporter.GetStudentAverageBySubject();
            var bestAverageBySubjects = reporter.GetBestAverageBySubjects(7.5f);
            printBestAverages(bestAverageBySubjects);
        }

        private static void printBestAverages(List<BestAverageBySubject> bestAverageBySubjects)
        {
            Printer.WriteTitle("MEJORES PROMEDIOS");
            foreach (var subject in bestAverageBySubjects)
            {
                Printer.DrawLine(5);
                Printer.WriteTitle(subject.Subject);
                foreach (var dictStudent in subject.BestAverage)
                {
                    foreach (var student in dictStudent)
                    {
                        WriteLine($"Estudiante: {student.Key}, Nota: {student.Value}");
                    }
                }
            }
        }

        private static void EventAction(object sender, EventArgs e)
        {
            WriteLine();
            Printer.WriteTitle("FIN DEL PROGRAMA");
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
