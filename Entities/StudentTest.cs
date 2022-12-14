namespace CoreSchool.Entities
{
    public class StudentTest : BaseSchoolObject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public float Grade { get; set; }

        public override string ToString()
        {
            return $"{Grade}, {Student.Name}, {Subject.Name}";
        }
    }
}