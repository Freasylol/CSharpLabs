using System;

class Fraction
{
    public Fraction()
    {

    }

    public Fraction(int numerator, int denomerator)
    {
        this.numerator = numerator;
        this.denomerator = denomerator;
    }

    public double ToDouble()
    {
        double doubleFraction = (double)numerator / (double)denomerator;
        return doubleFraction;
    }

    public int ToInt()
    {
        double doubleFraction = (double)numerator / (double)denomerator;
        Console.WriteLine(doubleFraction);
        int intFraction = (int)Math.Round(doubleFraction, MidpointRounding.AwayFromZero);
        return intFraction;
    }

    public override string ToString()
    {
        int numeratorLength = numerator.ToString().Length;
        int denomeratorLength = denomerator.ToString().Length;
        int hyphenLength = (numeratorLength > denomeratorLength) ? numeratorLength : denomeratorLength;
        string hyphenString = "";
        for (int i = 0; i < hyphenLength; i++)
        {
            hyphenString += "-";
        }
        return numerator.ToString() + "\n" + hyphenString + "\n" + denomerator.ToString() + "\n";
    }

    public string ToSpecialString()
    {   
        string hyphenString = "";
        string numeratorStarString = "";
        string denomeratorStarString = "";  
        for (int i = 0; i < numerator; i++)
        {
            numeratorStarString += "*";
        }
        for (int i = 0; i < denomerator; i++)
        {
            denomeratorStarString += "*";
        }
        int numeratorLength = numeratorStarString.Length;
        int denomeratorLength = denomeratorStarString.Length;
        int hyphenLength = (numeratorLength > denomeratorLength) ? numeratorLength : denomeratorLength;
        for (int i = 0; i < hyphenLength; i++)
        {
            hyphenString += "-";
        }
        return numeratorStarString + "\n" + hyphenString + "\n" + denomeratorStarString  + "\n";
    }

    public static Fraction operator +(Fraction firstArg, Fraction secondArg)
    {
        if (firstArg.denomerator == secondArg.denomerator)
        {
            Fraction fraction = new Fraction(firstArg.numerator + secondArg.numerator, firstArg.denomerator);
            Reduction(ref fraction);
            return fraction;
        }
        else
        {
            int temp = firstArg.denomerator;
            firstArg.denomerator *= secondArg.denomerator;
            firstArg.numerator *= secondArg.denomerator;
            secondArg.denomerator *= temp;
            secondArg.numerator *= temp;
            Fraction fraction = new Fraction(firstArg.numerator + secondArg.numerator, firstArg.denomerator);
            Reduction(ref fraction);
            return fraction;
        }

    }
    public static Fraction operator -(Fraction firstArg, Fraction secondArg)
    {
        if (firstArg.denomerator == secondArg.denomerator)
        {
            return new Fraction(firstArg.numerator - secondArg.numerator, firstArg.denomerator);
        }
        else
        {
            int temp = firstArg.denomerator;
            firstArg.denomerator *= secondArg.denomerator;
            firstArg.numerator *= secondArg.denomerator;
            secondArg.denomerator *= temp;
            secondArg.numerator *= temp;
            Fraction fraction = new Fraction(firstArg.numerator - secondArg.numerator, firstArg.denomerator);

            return fraction;
        }
    }
    public static Fraction operator *(Fraction firstArg, Fraction secondArg)
    {
        return new Fraction(firstArg.numerator * secondArg.numerator, firstArg.denomerator * secondArg.denomerator);
    }
    public static Fraction operator /(Fraction firstArg, Fraction secondArg)
    {
        return new Fraction(firstArg.numerator * secondArg.denomerator, firstArg.denomerator * secondArg.numerator);
    }

    public static bool operator >(Fraction firstArg, Fraction secondArg)
    {
        FractionComparer comparer = new FractionComparer();
        int result = comparer.Compare(firstArg, secondArg);
        if (result == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator <(Fraction firstArg, Fraction secondArg)
    {
        FractionComparer comparer = new FractionComparer();
        int result = comparer.Compare(firstArg, secondArg);
        if (result == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator ==(Fraction firstArg, Fraction secondArg)
    {
        FractionComparer comparer = new FractionComparer();
        int result = comparer.Compare(firstArg, secondArg);
        if (result == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator !=(Fraction firstArg, Fraction secondArg)
    {
        FractionComparer comparer = new FractionComparer();
        int result = comparer.Compare(firstArg, secondArg);
        if (result != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static int LCD(Fraction fraction)
    {
        int numerator = Math.Abs(fraction.numerator);
        int denomerator = Math.Abs(fraction.denomerator);
        while (denomerator != 0 && numerator != 0)
        {
            if (numerator % denomerator > 0)
            {
                int temp = numerator;
                numerator = denomerator;
                denomerator = temp % denomerator;
            } else
            {
                return denomerator;
            }
        }
        if (denomerator != 0 && numerator != 0)
        {
            return denomerator;
        }
        return denomerator;
    }

    public static void Reduction(ref Fraction fraction)
    {
        int lcd = LCD(fraction);
        fraction.numerator /= lcd;
        fraction.denomerator /= lcd;
    }

    public void SetNumerator(int value)
    {
        numerator = value;
    }
    public void SetDenomerator(int value)
    {
        denomerator = value;
    }
    public int GetNumerator()
    {
        return numerator;
    }
    public int GetDenomerator()
    {
        return denomerator;
    }

    private int numerator { get; set; }
    private int denomerator { get; set; }
}
