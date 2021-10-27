using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasWus.Utility
{
    public class InputValidation
    {
        public static bool IsAlphaNumeric(string str)
        {
            bool num = false;
            bool alpha = false;
            for (int i = 0; i < str.Length; i++)
            {

                if (char.IsLetter(str[i]))
                {
                    alpha = true;
                }
                if (char.IsNumber(str[i]))
                {
                    num = true;
                }
            }
            if (num == true && alpha == true)
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