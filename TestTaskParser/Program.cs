using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskParser.Core;
using TestTaskParser.Kinopoisk;

namespace TestTaskParser
{
    class Program
    {
        private static Manager<List<string>> _parser;

        private static async Task Main(string[] args)
        {
            _parser = new Manager<List<string>>(new KinopoiskParser(), new KinopoiskSettings());
            await _parser.Start();

            _parser.OnCompleted += Parser_OnCompleted;
            _parser.OnNewData += Parser_OnNewData;
        }

        private static void Parser_OnNewData(object arg1, List<string> arg2)
        {
            Console.WriteLine(arg2.ToString());
        }

        private static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("_____");
        }
    }
}
