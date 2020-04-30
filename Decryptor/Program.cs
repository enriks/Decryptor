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
            
            string texto1 = "FB";
            string texto2 = "B8";
            string texto3 = "CE";
            string partkey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23";// 9d2aea59ec1c7b5as91687bf6c825862f76b8e9f23";
            int part1 = Int32.Parse(texto1, System.Globalization.NumberStyles.HexNumber);
            int part2 = Int32.Parse(texto2, System.Globalization.NumberStyles.HexNumber);
            int part3 = Int32.Parse(texto3, System.Globalization.NumberStyles.HexNumber);

            List<string> DecriptedList = Tools.counter(part1,part2,part3,texto1,texto2,texto3,partkey);
            Console.ReadLine();
            
        }

    }
}
