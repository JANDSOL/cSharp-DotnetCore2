using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course
    {
        private string uniqueId;
        public string UniqueId { get; private set; }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private TypesWorkingDay workingDay;
        public TypesWorkingDay WorkingDay
        {
            get { return workingDay; }
            set { workingDay = value; }
        }

        private List<Subject> subjects;
        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public Course() => UniqueId = Guid.NewGuid().ToString();
    }
}