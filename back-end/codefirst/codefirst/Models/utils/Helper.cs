using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace codefirst.Models.utits
{
    public static class Helper
    {
        public static string GenHash(string input)
        {
            return string.Join("", new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input)).Select(x => x.ToString("X2")).ToArray());
        }

        public readonly static string AppKey = "dyxdgj4f54a5Z45l4u5o4l54545fi4o56s45457d8d4215g4fddsgbl";
        public readonly static string issuer = "https://localhost:44338";
    }
}
