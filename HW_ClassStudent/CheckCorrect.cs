﻿using System;
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
            Regex reg = new Regex(@"^(\+?\d{1,3})?[- ]?\d{2,3}[- ]?\d{2,3}[- ]?\d{2,3}[- ]?\d{2,3}$");
            Match result = reg.Match(phoneNumber);

            return result.Success;
        }

        static public bool CheckBirthYear(int year, int minYearsOld = 14, int maxYearsOld = 100)
        {
            return (DateTime.Now.Year - year) >= minYearsOld && (DateTime.Now.Year - year) <= maxYearsOld;
        }
    }
}
