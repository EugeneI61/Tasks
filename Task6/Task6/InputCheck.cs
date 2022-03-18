using System;
using System.Windows.Forms;

namespace Task6
{
    public class InputCheck
    {
        public bool AgeAccept(string age)
        {
            bool result = Int32.TryParse(age, out int valueResult) && (valueResult >= 18 && valueResult <= 99);

            return result;
        }
        public bool IsNull(string input)
        {
            bool result = string.IsNullOrEmpty(input) ;

            return result;
        }
    }
}
