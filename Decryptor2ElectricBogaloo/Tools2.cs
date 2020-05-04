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
            byte[] encrypted = Convert.FromBase64String(text);//toma el texto a desencriptar y lo combierte a bytes de base64
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(515);//crea el proveedor de servicio RSA con un tamaño de 515 bits como indicaba el texto desencriptado

            RSA.FromXmlString(xml);//lee de la clave en el xml
            
            Console.WriteLine(UTF8Encoding.UTF8.GetString(RSA.Decrypt(encrypted,false)));//escribe el texto desencriptado
            return UTF8Encoding.UTF8.GetString(RSA.Decrypt(encrypted, false));//devuelve el texto desencriptado

        }
    }
}
