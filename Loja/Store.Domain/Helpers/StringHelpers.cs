using System;
using System.Security.Cryptography;
using System.Text;

namespace Store.Domain.Helpers
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            var salt = "|B97C4A9F0503490FBB24F035323339C892530C4486B347EE9E0B4CB2ADAC9657";

            var arrayBytes = Encoding.UTF8.GetBytes(senha + salt);

            byte[] hashBytes;
            using (var sha = SHA512.Create())
            {
                hashBytes = sha.ComputeHash(arrayBytes);
            }

            return Convert.ToBase64String(hashBytes);
        }
    }
}
