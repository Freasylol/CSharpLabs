using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_8
{
    class Program
    {
        static void Concidences(string str)
        {

            for (int i = 0; i < 10; i++)
            {
                Regex regExp = new Regex(i.ToString());
                MatchCollection match = regExp.Matches(str);
                Console.WriteLine("{0} - {1}", i, match.Count);
            }
        }
        static void Main(string[] args)
        {
            DateTime dateAmerica = new DateTime();
            DateTime dateEurope = new DateTime();
            dateAmerica = DateTime.Now;
            dateEurope = DateTime.Now;
            string dateEuropeStr = dateEurope.ToString("dd/MM/yyyy HH:mm");
            string dateAmericaStr = dateAmerica.ToString("MM/dd/yyyy hh:mm tt");
            Console.WriteLine(String.Concat("Дата и время в европейском формате: ",
                              dateEuropeStr));
            Console.WriteLine(String.Concat("Дата и время в американском формате ",
                              dateAmericaStr));
            Console.WriteLine("Количество нулей, единиц ... девяток в записи дат: ");
            Console.WriteLine("В европейской записи: ");
            Concidences(dateEuropeStr);
            Console.WriteLine("В американской записи: ");
            Concidences(dateAmericaStr);
            Console.ReadLine();

        }
    }
}
