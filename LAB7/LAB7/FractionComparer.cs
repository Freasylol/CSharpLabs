using System;
using System.Collections.Generic;

class FractionComparer : IComparer<Fraction>
{
    public int Compare(Fraction firstArg, Fraction secondArg)
    {
        if (firstArg.GetDenomerator() == secondArg.GetDenomerator())
        {
            if (firstArg.GetNumerator() > secondArg.GetNumerator())
            {
                return 1;
            } else if (firstArg.GetNumerator() == secondArg.GetNumerator())
            {
                return 0;
            } else
            {
                return -1;
            }
        } else
        {
            int temp = firstArg.GetDenomerator();
            firstArg.SetDenomerator(firstArg.GetDenomerator() * secondArg.GetDenomerator());
            firstArg.SetNumerator(firstArg.GetNumerator() * secondArg.GetDenomerator());
            secondArg.SetDenomerator(secondArg.GetDenomerator() * temp);
            secondArg.SetNumerator(secondArg.GetNumerator() * temp);
            if (firstArg.GetNumerator() > secondArg.GetNumerator())
            {
                return 1;
            }
            else if (firstArg.GetNumerator() == secondArg.GetNumerator())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
      
        return 0;
    }
}
