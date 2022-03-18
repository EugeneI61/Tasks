using System;

namespace Task6
{
    public class InputCheck
    {
        public bool IsNumber(string input)
        {
            foreach (char result in input)
            {
                if (Char.IsNumber(result))
                    return true;
            }
            return false;
        }
        public bool AgeAccept(int age)
        {
            if (age >= 18 && age <= 99)
            {
                return true;
            }
            return false;
        }
    }
}
