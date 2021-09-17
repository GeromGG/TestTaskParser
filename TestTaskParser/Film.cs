using System.Collections.Generic;

namespace TestTaskParser
{
    public class Film
    {
        public string StartDate { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public string Director { get; set; }
        public List<string> Actor { get; set; }
    }
}
