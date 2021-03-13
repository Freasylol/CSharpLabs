using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_5
{
    class Program
    {
        static string SelectCapitalLetters(ref string str)
        {
            string processedInputUp = str.ToUpper();
            string output = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == processedInputUp[i])
                {
                    output += str[i].ToString();
                }
            }
            return output;
        }
        static string ProcessString(ref string str)
        {
            Regex regExp = new Regex("[A-Z]");
            string processedInput = regExp.Replace(str, "");
            return processedInput;
        }
        static void ReplaceSpaces(ref string str)
        {
            str = str.Trim();
            Regex regExp = new Regex(@"\s+");
            str = regExp.Replace(str, " ");
        }
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
        static bool CheckString(string str)
        {
            bool isWrongSymb = CheckWrongSymb(str);
            bool isEmpty = CheckStringEmpt(ref str);
            while ((isEmpty != false) || (isWrongSymb != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymb(str);
                isEmpty = CheckStringEmpt(ref str);
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string input = Console.ReadLine();
            bool isWrongStr = CheckString(input);
            if (isWrongStr != true)
            {
                ReplaceSpaces(ref input);
                string processedInput = ProcessString(ref input);
                string output = SelectCapitalLetters(ref processedInput);
                if (output.Length == 0)
                {
                    Console.WriteLine("Заглавных букв не входящих в английский алфавит не найдено");
                } else
                {
                    Console.WriteLine("Итоговая строка: {0}", output);
                }  
            }
            Console.ReadLine();
        } 
    }
}
