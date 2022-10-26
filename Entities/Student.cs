using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Student: BaseSchoolObject
    {
        public List<StudentTest> StudentTest { get; set; }

        public Student()
        {
            StudentTest = new List<StudentTest>(){};
        }
    }
}