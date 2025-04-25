using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhoIsThatMonke.Classes
{
    public class OffsetCalculatorCoolKidzOnly
    {
        List<bool> boolsForDaSools = new List<bool>();

        public void AddBool(bool value)
        {
            boolsForDaSools.Add(value);
        }

        public void ClearBoolsForDaSools()
        {
            boolsForDaSools.Clear();
        }

        public float CalculateOffsetCoolKidz()
        {
            return 2f + boolsForDaSools.Count(asdf => asdf);
        }
    }
}
