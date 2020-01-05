using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;
using Common.ViewModels;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Service.Helpers
{
    public class SimpleHash
    {
        public byte[] Hash(HashAlgorithm algorithm, byte[] input)
        {
            return algorithm.ComputeHash(input);
        }

        public string HexHash(HashAlgorithm algorithm, string text)
        {
            byte[] input = UnicodeEncoding.Unicode.GetBytes(text);
            return string.Concat(Hash(algorithm, input).Select(b => b.ToString("x2")));
        }

        public string Base64Hash(HashAlgorithm algorithm, string text)
        {
            byte[] input = UnicodeEncoding.Unicode.GetBytes(text);
            return Convert.ToBase64String(Hash(algorithm, input));
        }

        public PassInfo HMACSHA1(string password, string passSalt = null)
        {

            byte[] salt = new byte[128 / 8];

            if (passSalt != null)
                salt = Convert.FromBase64String(passSalt);
            else
            {
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }


            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return new PassInfo { Salt = Convert.ToBase64String(salt), Password = hashed.Replace("\"", "") };
        }
    }
}
