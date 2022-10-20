using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Student
    {
        private string uniqueId;
        public string UniqueId { get; private set; }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<StudentTest> studentTest;
        public List<StudentTest> StudentTest
        {
            get { return studentTest; }
            set { studentTest = value; }
        }

        public Student()
        {
            UniqueId = Guid.NewGuid().ToString();
            StudentTest = new List<StudentTest>(){};
        }
    }
}