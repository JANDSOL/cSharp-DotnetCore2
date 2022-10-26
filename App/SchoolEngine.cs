using System;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;
using CoreSchool.Util;

namespace CoreSchool.App
{
    public sealed class SchoolEngine
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

        public void PrintDictionary(
            Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dic,
            bool printStuTes = false
        )
        {
            foreach (var objDict in dic)
            {
                Printer.WriteTitle(objDict.Key.ToString());
                foreach (var value in objDict.Value)
                {
                    switch (objDict.Key)
                    {
                        case KeyDictionary.Evaluación:
                            if (printStuTes)
                                Console.WriteLine(value);
                            break;
                        case KeyDictionary.Escuela:
                            Console.WriteLine(value);
                            break;
                        case KeyDictionary.Alumno:
                            Console.WriteLine($"{KeyDictionary.Alumno}: {value.Name}");
                            break;
                        case KeyDictionary.Curso:
                            var temporalCourse = value as Course;
                            if (temporalCourse != null)
                            {
                                int studentsCount = temporalCourse.Students.Count;
                                Console.WriteLine(
                                    $"{KeyDictionary.Curso}: {value.Name}, Cantidad Alumnos: {studentsCount}"
                                );
                            }
                            break;
                        default:
                            Console.WriteLine(value);
                            break;
                    }
                }
            }
        }

        public Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> GetDictionaryObjects()
        {
            var myDictionary = new Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>>();

            myDictionary.Add(KeyDictionary.Escuela, new[] { School });
            myDictionary.Add(KeyDictionary.Curso, School.Courses);

            var temporalStudentTest = new List<StudentTest>();
            var temporalSubject = new List<Subject>();
            var temporalStudent = new List<Student>();
            foreach (var course in School.Courses)
            {
                temporalSubject.AddRange(course.Subjects);
                temporalStudent.AddRange(course.Students);

                foreach (var student in course.Students)
                {
                    temporalStudentTest.AddRange(student.StudentTest);
                }
            }
            myDictionary.Add(KeyDictionary.Asignatura, temporalSubject);
            myDictionary.Add(KeyDictionary.Alumno, temporalStudent);
            myDictionary.Add(KeyDictionary.Evaluación, temporalStudentTest);

            return myDictionary;
        }

        public IReadOnlyList<BaseSchoolObject> GetSchoolObjects(
            bool bringStudentTests = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            return GetSchoolObjects(
                out int dummy,
                out dummy,
                out dummy,
                out dummy
            );
        }

        public IReadOnlyList<BaseSchoolObject> GetSchoolObjects(
            out int countStudentTests,
            bool bringStudentTests = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            return GetSchoolObjects(
                out countStudentTests,
                out int dummy,
                out dummy,
                out dummy
            );
        }

        public IReadOnlyList<BaseSchoolObject> GetSchoolObjects(
            out int countStudentTests,
            out int countStudents,
            bool bringStudentTests = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            return GetSchoolObjects(
                out countStudentTests,
                out countStudents,
                out int dummy,
                out dummy
            );
        }

        public IReadOnlyList<BaseSchoolObject> GetSchoolObjects(
            out int countStudentTests,
            out int countStudents,
            out int countSubjects,
            bool bringStudentTests = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            return GetSchoolObjects(
                out countStudentTests,
                out countStudents,
                out countSubjects,
                out int dummy
            );
        }

        public IReadOnlyList<BaseSchoolObject> GetSchoolObjects(
            out int countStudentTests,
            out int countStudents,
            out int countSubjects,
            out int countCourses,
            bool bringStudentTests = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            countStudentTests = countStudents = countSubjects = 0;
            var listObj = new List<BaseSchoolObject>();
            listObj.Add(School);
            if (bringCourses)
            {
                listObj.AddRange(School.Courses);
            }
            countCourses = School.Courses.Count;
            foreach (var course in School.Courses)
            {
                countSubjects += course.Subjects.Count;
                countCourses += course.Students.Count;

                if (bringSubjects)
                {
                    listObj.AddRange(course.Subjects);
                }
                if (bringStudents)
                {
                    listObj.AddRange(course.Students);
                }

                if (bringStudentTests)
                {
                    foreach (var student in course.Students)
                    {
                        listObj.AddRange(student.StudentTest);
                        countStudentTests += student.StudentTest.Count;
                    }
                }
            }

            return listObj.AsReadOnly();
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

        #region Charging Methods (LoadStudentTests, LoadSubjects and LoadCourses)

        private void LoadStudentTests(int numberStudentTests)
        {
            var rnd = new Random();
            foreach (var course in School.Courses)
            {
                foreach (var subject in course.Subjects)
                {
                    foreach (var student in course.Students)
                    {

                        for (int i = 0; i < numberStudentTests; i++)
                        {
                            var stuTes = new StudentTest
                            {
                                Subject = subject,
                                Name = $"{subject.Name} Ev#{i + 1}",
                                Grade = MathF.Round(10 * (float)rnd.NextDouble(), 2),
                                Student = student
                            };
                            student.StudentTest.Add(stuTes);
                        }
                    }
                }
            }
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
        #endregion
    }
}