using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Decryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto1 = "00";
            string texto2 = "00";
            string texto3 = "00";
            string partkey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23";
            int part1 = Int32.Parse(texto1, System.Globalization.NumberStyles.HexNumber);
            int part2 = Int32.Parse(texto2, System.Globalization.NumberStyles.HexNumber);
            int part3 = Int32.Parse(texto3, System.Globalization.NumberStyles.HexNumber);

            Tools a = new Tools();
            List<string> aaaaa = a.counter(part1,part2,part3,texto1,texto2,texto3,partkey);
            a.CreateFile(aaaaa);
            Console.ReadLine();
        }

    }
}
