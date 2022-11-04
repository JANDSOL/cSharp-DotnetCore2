using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class BestAverageBySubject
    {
        public string Subject { get; set; }
        public List<Dictionary<string, float>> BestAverage { get; set; }
    }
}