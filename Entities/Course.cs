using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course: BaseSchoolObject
    {
        public TypesWorkingDay WorkingDay { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}