using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
public static class Checker {
    public delegate bool CheckHelper(ref string str);

    public static event CheckHelper Empty = (ref string str) => str.Length == 0;

    public static event CheckHelper WrongSymb = (ref string str) => {
        Regex regExp = new Regex(@"[0-9]");
        MatchCollection match = regExp.Matches(str);
            if (match.Count != str.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
    };
        

public delegate void CheckHandler(ref string str);

    public static void CheckWrongChoice(ref string str)
    {
        bool isWrongSymb = WrongSymb(ref str);
        bool isEmpty = Empty(ref str);
        try
        {
            if (isWrongSymb == false && isEmpty == false)
            {
                if (!Enum.IsDefined(typeof(Choice), int.Parse(str)))
                {
                    throw new Exception("Ошибка! Были введены неверные числа для выбора действия");
                }
            }
        }
        finally { }
    }

    public static void CheckWrongGender(ref string str)
    {
        bool isEmpty = Empty(ref str);
        bool isWrongSymb = WrongSymb(ref str);
        try
        {
            if (isWrongSymb == false && isEmpty == false)
            {
                if (!Enum.IsDefined(typeof(Gender), int.Parse(str)))
                {
                    throw new Exception("Ошибка! Были введены неверные числа для инициализации пола");
                }
            }
        }
        finally { }
    }

    public static void Check(ref string str, CheckHandler check)
    {
        try
        {
            check(ref str);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Повторите ввод");
            Console.WriteLine(ex.Message);
            str = Console.ReadLine();
            Check(ref str, check);
        }
    }

    public static void CheckStringEmpt(ref string str)
    {
        try
        {
            str = str.Trim();
            if (str.Length == 0)
            {
                throw new Exception("Ошибка! Символы не были введены.");
            }
        }
        finally { }
    }

    public static void CheckWrongSymb(ref string str)
    {
        string strUp = str.ToUpper(), strLow = str.ToLower();
        try
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str[i] == strLow[i]) && (str[i] == strUp[i]) && (str[i] != ' '))
                {
                    throw new Exception("Ошибка! Были введены недопустимые символы");
                }
            }
        }
        finally { }
    }

    public static void CheckNotNegative(ref string str)
    {
        bool isEmpty = Empty(ref str);
        try
        {
            if (isEmpty == false)
            {
                if (str[0] == '-')
                {
                    throw new Exception("Ошибка!Было введено отрицательное число");
                }
            }
        }
        finally { }
    }

    public static void CheckPositive(ref string str)
    {
        bool isEmpty = Empty(ref str);
        try
        {
            if (!isEmpty)
            {
                if (str[0] == '-' || str[0] == '0')
                {
                    throw new Exception("Ошибка!Было введено отрицательное число или ноль");
                }
            }
        }
        finally { }
    }

    public static void CheckWrongSymbInt(ref string str)
    {
        try
        {
            Regex regExp = new Regex(@"[0-9]");
            MatchCollection match = regExp.Matches(str);
            if (match.Count != str.Length)
            {
                throw new Exception("Ошибка были введены недопустимые символы");
            }
        }
        finally { }
    }

    public static CheckHandler ConfigCheckHandlerStr()
    {
        CheckHandler check = CheckWrongSymb;
        check += CheckStringEmpt;
        return check;
    }

    public static CheckHandler ConfigCheckHandlerInt()
    {
        CheckHandler check = CheckWrongSymbInt;
        check += CheckStringEmpt;
        check += CheckPositive;
        return check;
    }

    public static CheckHandler ConfigCheckHandlerGender()
    {
        CheckHandler check = CheckStringEmpt;
        check += CheckWrongSymbInt;
        check += CheckPositive;
        check += CheckWrongGender;
        return check;
    }

    public static CheckHandler ConfigCheckHandlerChoice()
    {
        CheckHandler check = CheckStringEmpt;
        check += CheckWrongSymbInt;
        check += CheckNotNegative;
        check += CheckWrongChoice;
        return check;
    }
}
