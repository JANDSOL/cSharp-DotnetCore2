using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSchool.Entities
{
    public class Courses
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

        public Courses() => UniqueId = Guid.NewGuid().ToString();
    }
}