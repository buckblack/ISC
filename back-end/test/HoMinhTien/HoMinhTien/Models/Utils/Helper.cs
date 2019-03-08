using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HoMinhTien.Models.Utils
{
    public class Helper
    {
        public static string GenHash(string input)
        {
            return string.Join("", new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input)).Select(x => x.ToString("X2")).ToArray());
        }

        public readonly static string AppKey = "hjgsfhgagyauihzbfufhgfaeiygiusfgwaesrggdfg";
        public readonly static string issuer = "https://localhost:44396";
    }
}
