using System;
using System.Collections.Generic;


class HumanComparer : IComparer<Human>
{
    public int Compare(Human first, Human second) => (first["age"] > second["age"] ? 1 : first["age"] < second["age"] ? -1 : 0);
}
