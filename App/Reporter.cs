using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSchool.Entities;

namespace CoreSchool.App
{
    public class Reporter
    {
        Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> _dictionary;
        public Reporter(Dictionary<KeyDictionary, IEnumerable<BaseSchoolObject>> dicShoObj)
        {
            if (dicShoObj == null)
                throw new ArgumentNullException(nameof(dicShoObj));
            _dictionary = dicShoObj;
        }

        public IEnumerable<StudentTest> GetStudentTestsList()
        {
            if (_dictionary.TryGetValue(KeyDictionary.Evaluación,
                out IEnumerable<BaseSchoolObject> myList)
            )
            {
                return myList.Cast<StudentTest>();
            }
            else
            {
                return new List<StudentTest>();
            }
        }

        public IEnumerable<string> GetSubjectsList()
        {
            return GetSubjectsList(out var dummy);
        }

        public IEnumerable<string> GetSubjectsList(
            out IEnumerable<StudentTest> stuTesList)
        {
            stuTesList = GetStudentTestsList();

            return (from StudentTest stuTes in stuTesList
                    select stuTes.Subject.Name).Distinct();
        }

        public Dictionary<string, IEnumerable<StudentTest>> GetStudentTestDicBySubject()
        {
            var dicAnswer = new Dictionary<string, IEnumerable<StudentTest>>();

            var subjectList = GetSubjectsList(out var stuTesList);

            foreach (var sub in subjectList)
            {
                var stuTes = from stuTest in stuTesList
                             where stuTest.Subject.Name == sub
                             select stuTest;
                dicAnswer.Add(sub, stuTes);
            }

            return dicAnswer;
        }

        public Dictionary<string, IEnumerable<object>> GetStudentAverageBySubject()
        {
            var answer = new Dictionary<string, IEnumerable<object>>();
            var dicStuTesBySub = GetStudentTestDicBySubject();

            foreach (var subAndStuTes in dicStuTesBySub)
            {
                var studentAverage = from stuTes in subAndStuTes.Value
                                     group stuTes by new
                                     {
                                         stuTes.Student.UniqueId,
                                         stuTes.Student.Name
                                     }
                                     into studentTestsGroup
                                     select new StudentAverage
                                     {
                                         studentId = studentTestsGroup.Key.UniqueId,
                                         studentName = studentTestsGroup.Key.Name,
                                         average = studentTestsGroup.Average(studentTest => studentTest.Grade)
                                     };
                answer.Add(subAndStuTes.Key, studentAverage);
            }

            return answer;
        }

        public List<BestAverageBySubject> GetBestAverageBySubjects(float bestAverageNum)
        {
            var answer = new List<BestAverageBySubject>();

            var studentAverageIEnum = GetStudentAverageBySubject();

            foreach (var studentAverage in studentAverageIEnum)
            {
                List<Dictionary<string, float>> temporalListOfDict = new List<Dictionary<string, float>>();
                var temporalIEnum = convertObjectToIEnumerableStuAve(studentAverage.Value, bestAverageNum);

                foreach (var listStudent in temporalIEnum)
                {
                    Dictionary<string, float> temporalDic = new Dictionary<string, float>(0);
                    temporalDic.Add(listStudent.studentName, listStudent.average);
                    temporalListOfDict.Add(temporalDic);
                }

                var obj = new BestAverageBySubject();
                obj.Subject = studentAverage.Key;
                obj.BestAverage = temporalListOfDict;
                answer.Add(obj);
            }
            return answer;
        }

        private IEnumerable<StudentAverage> convertObjectToIEnumerableStuAve(IEnumerable<object> obj, float bestAverageNum)
        {
            var answer = from StudentAverage student in obj
                         where student.average > bestAverageNum
                         group student by new
                         {
                             student.average,
                             student.studentId,
                             student.studentName
                         }
                         into studentGroup
                         select new StudentAverage
                         {
                             average = studentGroup.Key.average,
                             studentId = studentGroup.Key.studentId,
                             studentName = studentGroup.Key.studentName
                         };
            return answer;
        }
    }
}