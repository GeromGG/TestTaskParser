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
            //вместо консоли поставить взаимодействие с базой данных
            foreach (var item in arg2)
            {
                Console.WriteLine(item.StartDate);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Image);
                Console.WriteLine(item.Director);
                Console.WriteLine(String.Join(", ", item.Actor));
                Console.WriteLine(item.Rating.Contains(".") ? item.Rating : "—");
                Console.WriteLine(item.Description);
                Console.WriteLine("________________________________________________");
            }
            
        }

        private static void Parser_OnCompleted(object obj)
        {
            Console.WriteLine("___Конец___");
        }
    }
}
