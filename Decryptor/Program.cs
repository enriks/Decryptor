using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string texto1 = "00";//primeros 2 digitos de los 6 restantes
            string texto2 = "00";//segundos 2 digitos de los 6 restantes
            string texto3 = "00";//terceros 2 digitos de los 6 restantes
            string partkey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23";//parte de la clave recuperada para desencriptar el texto
            string textoEncriptado = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\resources\DOCUMENTO1.dat");//texto ecnriptado del archivo 1
            string nombreArchivo = "decriptedfile1";
            int part1 = Int32.Parse(texto1, System.Globalization.NumberStyles.HexNumber);//transforma el texto a hexadecimal y le asgina formato a al int para que sea haxadecimal
            int part2 = Int32.Parse(texto2, System.Globalization.NumberStyles.HexNumber);//transforma el texto a hexadecimal y le asgina formato a al int para que sea haxadecimal
            int part3 = Int32.Parse(texto3, System.Globalization.NumberStyles.HexNumber);//transforma el texto a hexadecimal y le asgina formato a al int para que sea haxadecimal

            List<string> DecriptedList = Tools.counter(part1,part2,part3,texto1,texto2,texto3,partkey, textoEncriptado);//usa el contador para obtener todas las combinaciones y el resultado de intentar desencriptarlas
            Tools.CreateFile(DecriptedList, nombreArchivo);//crea el archivo con los resultados
            Tools.getDecriptedText(nombreArchivo);
            Console.ReadLine();
            
        }

    }
}
