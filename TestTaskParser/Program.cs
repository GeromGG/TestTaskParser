using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTaskParser.Core;
using TestTaskParser.Kinopoisk;

namespace TestTaskParser
{
    class Program
    {
        private static Manager<List<Film>> _parser;

        private static async Task Main(string[] args)
        {
            try
            {
                _parser = new Manager<List<Film>>(new KinopoiskParser(), new KinopoiskSettings());
                _parser.OnCompleted += Parser_OnCompleted;
                _parser.OnNewData += Parser_OnNewData;
                await _parser.Start();
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }

        }

        private static void Parser_OnNewData(object arg1, List<Film> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item);
            }
            
        }

        private static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("_____");
        }
    }
}
