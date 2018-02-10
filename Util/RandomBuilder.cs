using System;

namespace Util
{
    public static class RandomBuilder
    {
        static Random rnd = new Random();
        static string pattern = "abcdefghijkmlnopqstuvwxyzABCDEFGHIJKLMNOPQRSTUVXYZ0123456789";
        public static string RandomString(int n)
        {
            char[] s = new char[n];
            for (int i = 0; i < n; i++)
            {
                int idx = rnd.Next(pattern.Length);
                s[i] = pattern[idx];
            }
            return new string(s);
        }
        public static long RandomLong()
        {
            return (long)Math.Round(rnd.NextDouble() * long.MaxValue, 0);
        }
    }
}
