using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace CorrectInput
{
    public class CheckCorrect
    {
        static public bool CheckString(string value, int minLen)
        {
            return value.Length >= minLen;
        }

        static public bool CheckDigit(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        static public bool CheckPhoneNumber(string phoneNumber)
        {
            // +380688998808
            // +38-068-899-88-08
            Regex reg = new Regex(@"^(\+?\d{1,3})?[- ]?\d{2,3}[- ]?\d{2,3}[- ]?\d{2,3}[- ]?\d{2,3}$");
            Match result = reg.Match(phoneNumber);

            return result.Success;
        }
    }
}
