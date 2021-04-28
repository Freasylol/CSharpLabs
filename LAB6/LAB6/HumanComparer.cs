using System;
using System.Collections.Generic;


    class HumanComparer : IComparer<Human>
    {
        public int Compare(Human firstArg, Human secondArg)
        {
            if (firstArg["age"] > secondArg["age"])
            {
                return 1;
            }
            else if (firstArg["age"] == secondArg["age"])
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
