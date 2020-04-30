using Decryptor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Decryptor2ElectricBogaloo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> archivo2 = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"\resources\DOCUMENTO2.DAT").ToList();
            List<string> result = new List<string>();
            archivo2.ForEach(frases=> {
                string[] mensaje = Regex.Split(frases,">");
                result.Add(Tools2.Decrypt(mensaje[1], File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\resources\publickey.xml")));
            });
            Tools.CreateFile(result,"decriptedFile2");
            
            Console.ReadLine();
        }
    }
}
