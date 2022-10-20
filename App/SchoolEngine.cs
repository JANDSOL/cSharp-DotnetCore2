using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;

namespace CoreSchool.App
{
    public class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine() { }

        public void Initialize()
        {
            School = new School("Juan's School", 2022, TypesSchool.Primaria,
                                    country: "Ecuador", city: "Quito");
            LoadCourses();
            LoadSubjects();
            GenerateRandomStudents(50);
            LoadStudentTests(5);
        }

        private void LoadStudentTests(int numberStudentTests)
        {
            foreach (var course in School.Courses)
            {
                foreach (var subject in course.Subjects)
                {
                    foreach (var student in course.Students)
                    {
                        var rnd = new Random(Environment.TickCount);

                        for (int i = 0; i < numberStudentTests; i++)
                        {
                            var stuTes = new StudentTest
                            {
                                Subject = subject,
                                Name = $"{subject.Name} Ev#{i + 1}",
                                Grade = (float)(5 * rnd.NextDouble()),
                                Student = student
                            };
                            student.StudentTest.Add(stuTes);
                        }
                    }
                }
            }
        }

        private List<Student> GenerateRandomStudents(int numberStudents)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listStudents = from n1 in name1
                               from n2 in name2
                               from lN1 in lastName1
                               select new Student { Name = $"{n1} {n2} {lN1}" };

            return listStudents.OrderBy(st => st.UniqueId).Take(numberStudents).ToList();
        }

        private void LoadSubjects()
        {
            foreach (var course in School.Courses)
            {
                List<Subject> listSubjects = new List<Subject>(){
                    new Subject {Name="Matemáticas"},
                    new Subject {Name="Educación Física"},
                    new Subject {Name="Castellanos"},
                    new Subject {Name="Ciencias Naturales"},
                };
                course.Subjects = listSubjects;
            }
            foreach (var course in School.Courses)
            {
                Random rnd = new Random();
                int studentsRandom = rnd.Next(5, 20);
                course.Students = GenerateRandomStudents(studentsRandom);
            }
        }

        private void LoadCourses()
        {
            School.Courses = new List<Course>(){
                new Course() { Name = "101", WorkingDay = TypesWorkingDay.Mañana },
                new Course() { Name = "201", WorkingDay = TypesWorkingDay.Mañana },
                new Course() { Name = "301", WorkingDay = TypesWorkingDay.Mañana },
                new Course() { Name = "401", WorkingDay = TypesWorkingDay.Tarde },
                new Course() { Name = "501", WorkingDay = TypesWorkingDay.Tarde },
            };
        }
    }
}