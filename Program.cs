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

            Printer.WriteTitle("¡Captura de evaluación por consola!");
            var newStudentTest = new StudentTest();
            string nameStuTes, gradeStuTesString;
            float gradeStuTes;

            Printer.PressEnter();
            Write("Ingrese el nombre de la evaluación: ");
            nameStuTes = ReadLine();
            try
            {
                newStudentTest.Name = nameStuTes.ToLower();
                if (string.IsNullOrWhiteSpace(nameStuTes))
                {
                    throw new ArgumentNullException("¡El valor del nombre no puede estar vacío!");
                }
                else
                {
                    WriteLine("El nombre de la evaluación fue ingresado correctamente.");
                }
            }
            catch (ArgumentNullException argNull)
            {
                WriteLine(argNull.ParamName);
                WriteLine("Saliendo del programa...");
                return;
            }

            Printer.PressEnter();
            Write($"Ingrese la calificación para \"{newStudentTest.Name}\": ");
            gradeStuTesString = ReadLine();
            try
            {
                gradeStuTes = float.Parse(gradeStuTesString);
                newStudentTest.Grade = gradeStuTes;
                if (gradeStuTes >= 0 && gradeStuTes <= 10)
                {
                    WriteLine($"La calificación de \"{newStudentTest.Name}\" se ingreso correctamente.");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("¡La calificación debe estar en un rango del 0 al 10!");
                }
            }
            catch (ArgumentOutOfRangeException argOut)
            {
                WriteLine(argOut.ParamName);
                return;
            }
            catch (Exception)
            {
                WriteLine("¡El valor para la calificación no puede estar vacío!");
                return;
            }
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
