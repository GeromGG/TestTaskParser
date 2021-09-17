using System.Collections.Generic;

namespace TestTaskParser.Interfaces
{
    public interface IClientSettings
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        //public int MaxAmount { get; set; }
    }
}
