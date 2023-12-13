using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class KeyGenerator
    {
        public string Key()
        {
            var bytes = new byte[16];
            var randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public string HMAC(string key, string message) => BitConverter
            .ToString(new HMACSHA256(Encoding.UTF8.GetBytes(key))
            .ComputeHash(Encoding.UTF8.GetBytes(message)))
            .Replace("-", "");   
    }
}
