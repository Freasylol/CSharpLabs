using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void AddElString(ref string[] output, string value)
        {
            Array.Resize(ref output, output.Length + 1);
            output[output.Length - 1] = value;

        }

        static void AddElString(ref string[] output, char value)
        {
            Array.Resize(ref output, output.Length + 1);
            output[output.Length - 1] = value.ToString();

        }

        static int Prior(string symbol)
        {
            switch (symbol[0])
            {
                case '*': case '/': return 3;
                case '+': case '-': return 2;
                case '(': return 1;
                case ')': return -1;
            }
            return 0;
        }

        static int Prior(char symbol)
        {
            switch (symbol)
            {
                case '*': case '/': return 3;
                case '+': case '-': return 2;
                case '(': return 1;
                case ')': return -1;
            }
            return 0;
        }

        static int OutputLength(ref string[] output)
        {
            int length = 0;
            for (int i = 0; i < output.Length; i++)
            {
                length += output[i].ToString().Length;
            }
            return length;
        }

        static bool CheckString(ref string exp, char[] symbols)
        {
            bool concidence = false;
            if (exp.Length == 0)
            {
                Console.WriteLine("Ошибка. Символы не были введены");
                while (concidence == false)
                {
                    Console.WriteLine("Повторите ввод");
                    exp = Console.ReadLine();
                    if (exp.Length != 0)
                    {
                        concidence = true;          
                    }
                }
                concidence = false;
            }
            for (int i = 0; i < exp.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (exp[i] == symbols[j])
                    {
                        concidence = true;
                    }
                    else if ((concidence == false) && (j + 1 == symbols.Length))
                    {
                        Console.WriteLine("Ошибка. Недопустимые символы! Повторите ввод");
                        Console.WriteLine("Введите арифметическое выражение ");
                        exp = Console.ReadLine();
                        concidence = CheckString(ref exp, symbols);
                    }
                }
            }
            return true;
        }

        static void GenPolStr(ref string[] output, string exp, ref Stack<string> operations)
        {
            int prior = 0, priorOp = 0;
            string number = "";
            for (int i = 0; i < exp.Length; i++)
            {
                prior = Prior(exp[i]);
                if (prior == 0)
                {
                    number += exp[i].ToString();
                    if ((i + 1 == exp.Length) && (exp.Length != OutputLength(ref output)) && (operations.Count() != 0))
                    {
                        AddElString(ref output, number);
                        while(operations.Count() != 0)
                        {
                            AddElString(ref output, operations.Pop());
                        }
                        
                    }
                }
                else
                {
                    AddElString(ref output, number);
                    number = "";
                    if (operations.Count() != 0)
                    {
                        priorOp = Prior(operations.Peek());
                        if (prior > priorOp)
                        {
                            operations.Push(exp[i].ToString());
                        }
                        else
                        {
                            while (operations.Count() != 0)
                            {
                                AddElString(ref output, operations.Pop());
                            }
                            operations.Push(exp[i].ToString());
                        }
                    }
                    else
                    {
                        operations.Push(exp[i].ToString());
                    }
                }
            }
        }

        static bool CountPolStr(ref string[] output, Stack<double> count)
        {
            bool error = false;
            int prior = 0;
            for (int i = 0; i < output.Length; i++)
            {
                prior = Prior(output[i]);
                if (prior == 0)
                {
                    count.Push(double.Parse(output[i].ToString()));
                }
                else
                {
                    if (output[i] == "+")
                    {
                        count.Push(count.Pop() + count.Pop());
                    }
                    else if (output[i] == "-")
                    {
                        double countDouble = count.Pop();
                        count.Push(count.Pop() - countDouble);
                    }
                    else if (output[i] == "*")
                    {
                        count.Push(count.Pop() * count.Pop());
                    }
                    else if (output[i] == "/")
                    {
                        double countDouble = count.Pop();
                        if (countDouble == 0)
                        {
                            Console.WriteLine("Ошибка. Деление на ноль!");
                            error = true;
                            break;
                        }
                        count.Push(count.Pop() / countDouble);
                    }
                }
            }
            return error;
        }

        static void Main(string[] args)
        {
            Stack<string> operations = new Stack<string>();
            Stack<double> count = new Stack<double>();
            string exp;
            char[] symbols = new char[] {'(', ')', '+', '-', '/', '^', '.', '0', '1',
                                         '2', '3', '4' , '5' ,  '6' , '7', '8', '9'};
            string[] output = new string[0];
            Console.WriteLine("Введите арифметическое выражение ");
            exp = Console.ReadLine();
            CheckString(ref exp, symbols);
            Console.WriteLine("Исходное выражение: " + exp);

            GenPolStr(ref output, exp, ref operations);
            operations.Clear();
            string outputStr = "";
            for (int i = 0; i < output.Length; i++)
            {
                outputStr += output[i] + ", ";
            }
            Console.WriteLine("Выражение в виде польской строки: " + outputStr);

            if (CountPolStr(ref output, count) == false)
            {
                double result = count.Pop();
                Console.WriteLine("Результат: " + result);
            }
            Console.ReadLine();
        }
    }
}