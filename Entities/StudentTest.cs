using System;

namespace CoreSchool.Entities
{
    public class StudentTest
    {
        private string uniqueId;
        public string UniqueId { get; private set; }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private float grade;
        public float Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public StudentTest() => UniqueId = Guid.NewGuid().ToString();
    }
}