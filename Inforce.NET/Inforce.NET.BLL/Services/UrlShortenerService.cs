using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inforce.NET.BLL.Services
{
    public class UrlShortenerService
    {
        public static readonly string Chars = "abcdefghijklmnopqrstuvwxyz0123456789./%&?!@#=:ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly int Base = Chars.Length;

        public static string GenerateShortUrl(int i)
        {
            if (i == 0) return Chars[0].ToString();

            var s = string.Empty;

            while (i > 0)
            {
                s += Chars[i % Base];
                i /= Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        public static int GenerateKey(string s)
        {
            var i = 0;

            foreach (var c in s)
            {
                i = (i * Base) + Chars.IndexOf(c);
            }

            return i;
        }
    }
}
