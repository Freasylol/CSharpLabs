using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_2
{
    class Program
    {
        static bool CheckStringEmpt(ref string str)
        {
            bool isEmpty = false;
            if (str.Length == 0)
            {
                Console.WriteLine("Ошибка! Символы не были введены.");
                isEmpty = true;
            }
            else if (str.Length != 0)
            {
                isEmpty = false;
            }
            return isEmpty;
        }
        static bool CheckWrongSymb(string str)
        {
            bool isWrongSymb = false;
            string strUp = str.ToUpper(), strLow = str.ToLower();
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] == strLow[i]) && (str[i] == strUp[i]) && (str[i] != ' '))
                {
                    isWrongSymb = true;
                    Console.WriteLine("Были введены недопустимые символы");
                    break;
                }
            }
            return isWrongSymb;
        }
        static bool CheckString(string str) {
            bool isWrongSymb = CheckWrongSymb(str);
            bool isEmpty = CheckStringEmpt(ref str);
            while ((isEmpty != false) || (isWrongSymb != false)) {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymb(str);
                isEmpty = CheckStringEmpt(ref str);
            }
            return false;
        }
        static void ReplaceSpaces(ref string str)
        {
            str = str.Trim();
            Regex regExp = new Regex(@"\s+");
            str = regExp.Replace(str, " ");
        }
        static string ReverseOrderStr(string str)
        {
            string strProcessed = "";
            string[] strArr = str.Split(new char[] { ' ' });
            Array.Reverse(strArr);
            foreach (string el in strArr)
            {
                strProcessed = String.Concat(strProcessed, el, " ");
            }
            return strProcessed;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string input = Console.ReadLine();
            bool isWrongStr = CheckString(input);   
            if (isWrongStr != true) {
                string output = input;
                ReplaceSpaces(ref output);
                output = ReverseOrderStr(output);
                Console.WriteLine("Исходная строка: {0}", input);
                Console.WriteLine("Строка в обратном порядке слов: {0}", output);
            } 
            Console.ReadLine();
        }
    }
}
