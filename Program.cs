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

            // Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            // myDictionary.Add(10, "JuanK");
            // myDictionary.Add(23, "Lorem Ipsum");
            // foreach (var keyValPair in myDictionary)
            // {
            //     WriteLine($"Key: {keyValPair.Key}, Valor: {keyValPair.Value}");
            // }

            var dictmp = engine.GetDictionaryObjects();

            engine.PrintDictionary(dictmp, printStuTes: true);
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
