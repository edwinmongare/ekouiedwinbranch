using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Retail.Data.Helpers
{
    public static class RandomNumberGenerator
    {
        public static string GetCustomerNumber(string prefix) => $"{prefix}{RandomCode(11)}";
        public static string GetAccountNumber(string prefix) => $"{prefix}{RandomCode(8)}";
        static string RandomCode(int length)
        {
            var numbers = "1234567890";
            var allowedChars = numbers;
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("Length", "Length cannot be zero");
            }
            if (string.IsNullOrEmpty(allowedChars))
            {
                throw new ArgumentException("AllowedChars cannot be empty");
            }
            var byteSize = 256;
            var hash = new HashSet<char>(allowedChars);
            var allowedCharSet = hash.ToArray();
            if (byteSize < allowedCharSet.Length)
            {
                throw new ArgumentException($"AllowedChars cannot contain more than {byteSize}");
            }
            var rng = new RNGCryptoServiceProvider();
            var result = new StringBuilder();
            var buff = new byte[128];
            while (result.Length < length)
            {
                rng.GetNonZeroBytes(buff);
                for (int i = 0; i <= buff.Length - 1; i++)
                {
                    if (result.Length >= length)
                    {
                        break;
                    }
                    var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
                    if (outOfRangeStart <= buff[i])
                    {
                        continue;
                    }
                    result.Append(allowedCharSet[buff[i] % allowedCharSet.Length]);
                }
            }
            //  ComputeSha256Hash(result.ToString());
            return result.ToString();
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
