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

        static bool CheckStringOp(ref string exp, char[] symbolsOp, ref int opCount)
        {
            bool concidence = false;
            for (int i = 0; i < exp.Length; i++)
            {
                for (int j = 0; j < symbolsOp.Length; j++)
                {
                    if (exp[i] == symbolsOp[j])
                    {
                        opCount++;
                    }
                }
            }
            if (opCount == 0)
            {
                Console.WriteLine("Ошибка нет символов операций");
            } else
            {
                concidence = true;
            }
            return concidence;
        }

        static bool CheckStringNum(ref string exp, char[] symbolsNum, char[] symbolsOp,ref int numCount)
        {
            bool concidence = false;
            bool isOperation = true;
            for (int i = 0; i < exp.Length; i++)
            {
                for (int j = 0; j < symbolsNum.Length; j++)
                {
                    if (exp[i] == symbolsNum[j])
                    {
                        numCount++;
                        while (isOperation)
                        {
                            if (i + 1 >= exp.Length)
                            {
                                break;
                            }
                            i++;
                           
                            for (int z = 0; z < symbolsOp.Length; z++)
                            {
                                if (exp[i] == symbolsOp[z])
                                {
                                    isOperation = false;
                                    break;
                                }
                            }
                        }
                        isOperation = true;
                    }
                }
            }
            if (numCount == 0)
            {
                Console.WriteLine("Ошибка нет цифр");
            } else
            {
                concidence = true;
            }
            return concidence;
        }

        static bool CheckStringEmpt(ref string exp)
        {
            bool concidence = false;
            if (exp.Length == 0)
            {
                Console.WriteLine("Ошибка. Символы не были введены");
            } else if (exp.Length != 0)
            {
                concidence = true;
            }
            return concidence;
        }

        static bool CheckStringSymb(ref string exp, char[] symbols)
        {
            bool concidence = false;
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
                        Console.WriteLine("Ошибка. Недопустимые символы!");
                        return concidence;
                    }
                }
            }
            return concidence;
        }

        static bool CheckCount (ref int opCount, ref int numCount)
        {
            bool conformity = false;
            if (numCount - opCount == 1)
            {
                conformity = true;
            } else
            {
                Console.WriteLine("Ошибка! Количество цифр не соответсвует количеству операций.");
                conformity = false;
            }
            numCount = 0;
            opCount = 0;
            return conformity;
        }
         
        static bool CheckString(ref string exp, char[] symbols, char[] symbolsOp, char[] symbolsNum)
        {
            int opCount = 0, numCount = 0;
            bool coincidenceEmpt = CheckStringEmpt(ref exp);
            bool coincidenceSymb = CheckStringSymb(ref exp, symbols);
            bool coincidenceOp = CheckStringOp(ref exp, symbolsOp, ref opCount);
            bool coincidenceNum = CheckStringNum(ref exp, symbolsNum, symbolsOp, ref numCount);
            bool countCheck = CheckCount(ref opCount, ref numCount);
            {
                while ((coincidenceEmpt != true) || (coincidenceSymb != true) ||
                   (coincidenceOp != true) || (coincidenceNum != true) || (countCheck != true))
                {
                    Console.WriteLine("Повторите ввод");
                    exp = Console.ReadLine();
                    coincidenceEmpt = CheckStringEmpt(ref exp);
                    coincidenceSymb = CheckStringSymb(ref exp, symbols);
                    coincidenceOp = CheckStringOp(ref exp, symbolsOp, ref opCount);
                    coincidenceNum = CheckStringNum(ref exp, symbolsNum, symbolsOp, ref numCount);
                    countCheck = CheckCount(ref opCount, ref numCount);
                }
            } 
            return true;
        }

        static void GenPolStr(ref string[] output, string exp, ref Stack<string> operations)
        {
            int prior, priorOp;
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
                        while (operations.Count() != 0)
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
            int prior;
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
                                         '2', '3', '4', '5',  '6', '7', '8', '9'};
            char[] symbolsOp = new char[] {'+', '-', '/', '^'};
            char[] symbolsNum = new char[] {'0', '1','2', '3', '4', '5', '6', 
                                            '7', '8', '9'};
            string[] output = new string[0];
            Console.WriteLine("Введите арифметическое выражение ");
            exp = Console.ReadLine();
            CheckString(ref exp, symbols, symbolsOp, symbolsNum);
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