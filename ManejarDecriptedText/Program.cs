using Decryptor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejarDecriptedText
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> encripted = File.ReadLines(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + @"\Decryptor\bin\debug\resources\decripted.txt").ToList();
            //Console.WriteLine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + @"\Decryptor\bin\debug\resources\decripted.txt");
            
            List<string> noVacios = new List<string>();
            List<string> desencriptado = new List<string>();
            encripted.ForEach(lineas => {
                if (!(lineas.ToCharArray().Length == 9)) {//saca los vacios
                    noVacios.Add(lineas);
                }
            });
            noVacios.ForEach(novacios =>
            {
                if (!novacios.Contains("�")&&novacios.ToCharArray().Length>25)//busca un mensaje que no tenga � y que sea lo suficientemente largo como para ser el desencriptado
                {
                    Console.WriteLine(novacios);
                    desencriptado.Add(novacios);
                }
            });
            Tools.CreateFile(desencriptado, "decripted5");
            Console.ReadLine();
        }
    }
}
