using System.Security.Cryptography;


namespace DAL
{
    static class Hash
    {
        static byte[] Execute(string hashName, string plainText)
        {
            HashAlgorithm algorithm = HashAlgorithm.Create(hashName);
            return algorithm.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(plainText));
        }
        public static byte[] MD5(string plainText)
        {
            return Execute("MD5", plainText);
        }
    }
}
