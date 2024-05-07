using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace HiTechClassLibrary.VALIDATION
{
    public static class Validator
    {
        public static bool IsDecimalNumber(string input)
        {
            if (Regex.IsMatch(input, @"^\d*\.?\d*$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsNumber(string input)
        {
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidId(string input, int length)
        {
            if (Regex.IsMatch(input, @"^\d{" + length + "}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidName(string input)
        {
            if (Regex.IsMatch(input, @"^([a-zA-Z]|\s)+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string input)
        {
            if (Regex.IsMatch(input, @"^\(\d{3}\).?\d{3}-\d{4}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidEmail(string input)
        {
            if (Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidPassword(string input)
        {
            if (Regex.IsMatch(input, @"^\w+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidWebsite(string input)
        {
            if (Regex.IsMatch(input, @"^https:\/\/(\w|\.)+\.com\/$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidYearPublished(string input)
        {
            if (Regex.IsMatch(input, @"^(19|20)\d{1}\d{1}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
