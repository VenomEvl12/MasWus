using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace MasWus.Utility
{
    public class HashFunction
    {
        public static string Sha256(string str)
        {
            StringBuilder sb = new StringBuilder();
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding obj = new UTF8Encoding();
            hashValue = sha256.ComputeHash(obj.GetBytes(str));
            foreach(Byte b in hashValue)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}