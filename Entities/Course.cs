using System;
using System.Collections.Generic;
using CoreSchool.Util;

namespace CoreSchool.Entities
{
    public class Course : BaseSchoolObject, IntAddress
    {
        public TypesWorkingDay WorkingDay { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
        public string Address { get; set; }

        public void ClearSpace()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Establecimiento...");
            Console.WriteLine($"Curso {Name} Limpio...");
        }
    }
}