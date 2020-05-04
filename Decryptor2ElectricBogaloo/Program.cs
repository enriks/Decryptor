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
            List<string> archivo2 = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"\resources\DOCUMENTO2.DAT").ToList();//toma el archivo a desencriptar
            List<string> result = new List<string>();//lista que obtendra los resultados de la desencriptacion
            archivo2.ForEach(frases=> {//foreach que mira cada linea del archivo 2
                string[] mensaje = Regex.Split(frases,">");//separa el texto a desencriptar de las instrucciones
                result.Add(Tools2.Decrypt(mensaje[1], File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\resources\publickey.xml")));//desencripta el texto y lo agrega a la lista
            });
            Tools.CreateFile(result,"decriptedFile2");//crea el archivo con los resultados
            
            Console.ReadLine();
        }
    }
}
