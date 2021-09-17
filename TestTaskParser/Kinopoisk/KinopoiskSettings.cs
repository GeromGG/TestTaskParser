using System.Collections.Generic;
using TestTaskParser.Interfaces;

namespace TestTaskParser.Kinopoisk
{
    class KinopoiskSettings : IClientSettings
    {
        public string BaseUrl { get; set; } = "https://www.kinopoisk.ru";
        public string Prefix { get; set; } = "premiere";
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>() 
        {
            { "Accept-Language", "ru-Ru,ru;q=0.5" },
            { "Accept-Charset", "Windows-1252,utf-8;q=0.7,*;q=0.7" },
            { "UserAgent", "Opera/9.80 (Windows NT 6.1; WOW64; MRA 8.2 (build 6870)) Presto/2.12.388 Version/12.16" },
        };
    }
}
