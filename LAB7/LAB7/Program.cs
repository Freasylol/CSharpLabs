using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LAB7
{
    class Program
    {
        static void Push<T>(ref T[] arr, T value)
        {
            T[] newArray = new T[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                newArray[i] = arr[i];
            }

            newArray[arr.Length] = value;

            arr = newArray;
        }

        static void CheckFraction(ref string str)
        {
            bool isWrongSymb = CheckWrongSymbFraction(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isWrongArgs = false;
            bool isRightLength = false;
            if (str.IndexOf("/") != -1)
            {
                isWrongArgs = CheckArgs(ref str, isEmpty);
                isRightLength = (str.Length >= 3) ? false : true;
                if (isRightLength)
                {
                    Console.WriteLine("Вы ввели строку неверной длины");
                }
            }

            while ((isEmpty != false) || (isWrongSymb != false) || (isRightLength != false) ||
                  (isWrongArgs != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymbFraction(str);
                isEmpty = CheckStringEmpt(ref str);
                if (str.IndexOf("/") != -1)
                {
                    isWrongArgs = CheckArgs(ref str, isEmpty);
                    isRightLength = (str.Length >= 3) ? false : true;
                    if (isRightLength)
                    {
                        Console.WriteLine("Вы ввели строку неверной длины");
                    }
                }
            }
        }

        static bool CheckArgs(ref string str, bool isEmpty)
        {
            bool isWrongArgs = false;
            int index = str.IndexOf("/");
            string firstArg = str.Substring(0, index);
            bool isFirstArgWrong = CheckWrongSymbInt(firstArg);
            string secondArg = str.Substring(index + 1);
            bool isSecondArgWrong = CheckNotNullOrNegative(secondArg, isEmpty);
            if ((isFirstArgWrong != false) || (isSecondArgWrong != false))
            {
                Console.WriteLine("Были введены неверные аргументы");
                isWrongArgs = true;
            }
            isFirstArgWrong = CheckStringEmpt(ref firstArg);
            isSecondArgWrong = CheckStringEmpt(ref firstArg);
            if ((isFirstArgWrong != false) || isSecondArgWrong != false)
            {
                Console.WriteLine("Были введены неверные аргументы");
                isWrongArgs = true;
            }
            return isWrongArgs;
        }

        static Fraction FractionCreation(string str)
        {
            int index = str.IndexOf("/");
            if (index != -1)
            {
                int firstArg = int.Parse(str.Substring(0, index));
                int secondArg = int.Parse(str.Substring(index + 1));
                return new Fraction(firstArg, secondArg);
            }
            else
            {
                return new Fraction(int.Parse(str), 1);
            }
        }

        static void FractionSum(Fraction firstArg, Fraction secondArg, int variantOfInput)
        {
            if (variantOfInput == 1)
            {
                Console.WriteLine(firstArg + secondArg);
            }
            else
            {
                Console.WriteLine((firstArg + secondArg).ToSpecialString());
            }

        }

        static void FractionDiff(Fraction firstArg, Fraction secondArg, int variantOfInput)
        {
            if (variantOfInput == 1)
            {
                Console.WriteLine(firstArg - secondArg);
            }
            else
            {
                Console.WriteLine((firstArg - secondArg).ToSpecialString());
            }

        }


        static void FractionMult(Fraction firstArg, Fraction secondArg, int variantOfInput)
        {
            if (variantOfInput == 1)
            {
                Console.WriteLine(firstArg * secondArg);
            }
            else
            {
                Console.WriteLine((firstArg * secondArg).ToSpecialString());
            }
        }
        static void FractionDiv(Fraction firstArg, Fraction secondArg, int variantOfInput)
        {
            if (variantOfInput == 1)
            {
                Console.WriteLine(firstArg / secondArg);
            }
            else
            {
                Console.WriteLine((firstArg / secondArg).ToSpecialString());
            }
        }

        static bool CheckStringEmpt(ref string str)
        {
            bool isEmpty = false;
            str = str.Trim();
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

        static bool CheckNotNullOrNegative(string str, bool isEmpty)
        {
            bool isNegative = false;
            if (isEmpty == false)
            {
                if (str[0] == '-' || str[0] == '0')
                {
                    Console.WriteLine("Ошибка! Было введено отрицательное число или ноль");
                    isNegative = true;
                }
            }
            return isNegative;
        }

        static void CheckNaturalInt(ref string str)
        {
            bool isWrongSymb = CheckWrongSymbInt(str);
            bool isEmpty = CheckStringEmpt(ref str);
            bool isNegativeOrNull = CheckNotNullOrNegative(str, isEmpty);
            while ((isEmpty != false) || (isWrongSymb != false)
                    || (isNegativeOrNull != false))
            {
                Console.WriteLine("Повторите ввод");
                str = Console.ReadLine();
                isWrongSymb = CheckWrongSymbInt(str);
                isEmpty = CheckStringEmpt(ref str);
                isNegativeOrNull = CheckNotNullOrNegative(str, isEmpty);
            }
        }

        static bool CheckWrongSymbFraction(string str)
        {
            bool isWrongSymb = false;
            Regex regExp = new Regex(@"[0-9]");
            Regex regExpSlash = new Regex(@"/");
            MatchCollection match = regExp.Matches(str);
            MatchCollection matchSlash = regExpSlash.Matches(str);
            if ((match.Count != str.Length) && (matchSlash.Count > 1))
            {
                Console.WriteLine("Ошибка были введены недопустимые символы или более одного слеша");
                isWrongSymb = true;
            }
            return isWrongSymb;
        }

        static bool CheckWrongSymbInt(string str)
        {
            bool isWrongSymb = false;
            Regex regExp = new Regex(@"[0-9]");
            MatchCollection match = regExp.Matches(str);
            if (match.Count != str.Length)
            {
                Console.WriteLine("Ошибка были введены недопустимые символы");
                isWrongSymb = true;
            }
            return isWrongSymb;
        }

        static Fraction FractionInput(ref Fraction fraction)
        {
            Console.WriteLine("Введите дробь");
            string fractionStr = Console.ReadLine();
            CheckFraction(ref fractionStr);
            fraction = FractionCreation(fractionStr);
            Console.WriteLine(fraction);
            return fraction;
        }

        static void Main(string[] args)
        {
            Console.Write("Введите операцию, которую хотите выполнить с дробями(1 - сложение, " +
                          "2 - вычитание, 3 - умножение, 4 - деление, 5 - сравнение, " +
                          "6 - перевод обычной дроби в десятичную, 7 - перевод обычной дроби в целое число)\n");
            string operationChoiceStr = Console.ReadLine();
            CheckNaturalInt(ref operationChoiceStr);
            int operationChoice = int.Parse(operationChoiceStr);
            Console.WriteLine("Введите формат в котором хотите вывести дробь(1 - обычный, 2 - специальный(звёздочки вместо цифр))");
            string formatChoiceStr = Console.ReadLine();
            CheckNaturalInt(ref formatChoiceStr);
            int formatChoice = int.Parse(formatChoiceStr);
            Fraction fraction = new Fraction();
            FractionInput(ref fraction);
            Fraction fraction2 = new Fraction();

            switch (operationChoice)
            {
                case 1:
                    FractionInput(ref fraction2);
                    Console.WriteLine("Сумма равна:");
                    FractionSum(fraction, fraction2, formatChoice);
                    break;
                case 2:
                    FractionInput(ref fraction2);
                    Console.WriteLine("Разность равна:");
                    FractionDiff(fraction, fraction2, formatChoice);
                    break;
                case 3:
                    FractionInput(ref fraction2);
                    Console.WriteLine("Произведение равно: ");
                    FractionMult(fraction, fraction2, formatChoice);
                    break;
                case 4:
                    FractionInput(ref fraction2);
                    Console.WriteLine("Частное равно: ");
                    FractionDiv(fraction, fraction2, formatChoice);
                    break;
                case 5:
                    FractionInput(ref fraction2);
                    if (fraction == fraction2)
                    {
                        Console.WriteLine("Дроби равны");
                    }
                    else if (fraction > fraction2)
                    {
                        Console.WriteLine("Первая дробь больше, чем вторая");
                    }
                    else
                    {
                        Console.WriteLine("Вторая дробь больше, чем первая");
                    }
                    break;
                case 6:
                    Console.WriteLine(((double)fraction).ToString());
                    break;
                case 7:
                    Console.WriteLine(((int)fraction).ToString());
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
