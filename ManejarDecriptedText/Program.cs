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
            List<string> encripted = File.ReadLines(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + @"\Decryptor\bin\debug\resources\decripted.txt").ToList();// lee el archivo desencriptado
            
            List<string> noVacios = new List<string>();//lista que guardara los resultados que no tuvieron error al momento de desencriptar
            List<string> desencriptado = new List<string>();//lista con el resultado de la desenciptacion
            encripted.ForEach(lineas => {
                if (!(lineas.ToCharArray().Length == 9)) {//saca los vacios
                    noVacios.Add(lineas);//agrega los no vacios a la lista
                }
            });
            noVacios.ForEach(novacios =>
            {
                if (!novacios.Contains("�")&&novacios.ToCharArray().Length>25)//busca un mensaje que no tenga � y que sea lo suficientemente largo como para ser el desencriptado
                {
                    Console.WriteLine(novacios);//imprime los que no tienen �
                    desencriptado.Add(novacios);//agrega a la lista los resultados que no tienen �
                }
            });
            Tools.CreateFile(desencriptado, "decripted5");//crea el archivo
            Console.ReadLine();
        }
    }
}
