using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Decryptor2ElectricBogaloo
{
    class Tools2
    {
        public static string Decrypt(string text, string xml)
        {
            byte[] encrypted = Convert.FromBase64String(text);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(515);

            RSA.FromXmlString(xml);
            
            Console.WriteLine(UTF8Encoding.UTF8.GetString(RSA.Decrypt(encrypted,false)));
            return UTF8Encoding.UTF8.GetString(RSA.Decrypt(encrypted, false));

        }
    }
}
