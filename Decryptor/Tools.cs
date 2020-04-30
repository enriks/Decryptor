using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Decryptor
{
    public class Tools
    {
        public static List<string> counter(int part1, int part2, int part3,string texto1,string texto2,string texto3,string partkey)
        {
            List<string> combinaciones = new List<string>();
           while(part1 <= 0xFF && part2 <= 0xFF && part3 < 0xFF)
            {
                if (part1 < 0xFF)
                {
                    part1++;
                    texto1 = string.Format("{0:X2}", part1);
                    Console.WriteLine(texto1 + texto2 + texto3);
                    combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                }
                else
                {
                    part1 = 00;
                    texto1 = string.Format("{0:X2}", part1);
                    Console.WriteLine(texto1 + texto2 + texto3);
                    combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                    if (part2 < 0xFF)
                    {
                        part2++;
                        texto2 = string.Format("{0:X2}", part2);
                        Console.WriteLine(texto1 + texto2 + texto3);
                        combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                    }
                   else
                    {
                        part2 = 00;
                        texto2 = string.Format("{0:X2}", part2);
                        Console.WriteLine(texto1 + texto2 + texto3);
                        combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                        if (part3 < 0xFF)
                        {
                            part3++;
                            texto3 = string.Format("{0:X2}", part3);
                            Console.WriteLine(texto1 + texto2 + texto3);
                            combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                        }
                        else
                        {
                            part3 = 00;
                            texto3 = string.Format("{0:X2}", part3);
                            Console.WriteLine(texto1 + texto2 + texto3);
                            combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));
                        }
                    }
                }
            }
            return combinaciones;

        }


        public static string TryDecrypt(string keys)
        {
            string encripted = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\resources\DOCUMENTO1.dat");
            Console.WriteLine(encripted);
            byte[] key;
            using (var hashmd5 = new MD5CryptoServiceProvider())
            {
                key = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(keys));
            }
            
            byte[] data = Convert.FromBase64String(encripted);
            using (var tdes = new TripleDESCryptoServiceProvider
            {
                Key = key,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            })
            using (var transform = tdes.CreateDecryptor())
            {
                try
                {
                    var resultArray = transform.TransformFinalBlock(data, 0, data.Length);

                    return Encoding.UTF8.GetString(resultArray);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    return string.Empty;
                }
            }
        }

        public static void CreateFile(List<string> contenido,string nombreArchivo)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\resources\"+nombreArchivo+".txt";
            Console.WriteLine(fileName);
            try
            {    
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (FileStream fs = File.Create(fileName))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("desencriptado");
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("manuel coto");
                    fs.Write(author, 0, author.Length);
                    Console.WriteLine("creo el archivo");
                }

                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach(string line in contenido){
                        sw.WriteLine(line);
                    }
                    Console.WriteLine("termino");
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
