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
        public static List<string> counter(int part1, int part2, int part3,string texto1,string texto2,string texto3,string partkey)//funcion contadora
        {
            List<string> combinaciones = new List<string>();//creacion de la lista que guardara las combianaciones y los resultados
           while(part1 <= 0xFF && part2 <= 0xFF && part3 < 0xFF)//contador que llegara hasta FFFFFF
            {
                if (part1 < 0xFF)//condicional que verifica si los primeros 2 digitos de los 6 faltantes son menores a FF
                {
                    part1++;//si los primeros 2 digitos son menores a FF suma uno a los 2 digitos
                    texto1 = string.Format("{0:X2}", part1);//aplica formato haxadecimal al numero sumado
                    Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                    combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                }
                else
                {
                    part1 = 00;// si los primeros 2 digitos son mayores a FF los vuelve a 00
                    texto1 = string.Format("{0:X2}", part1);//aplica formato haxadecimal al numero sumado
                    Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                    combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                    if (part2 < 0xFF)
                    {
                        part2++;//si es menor a FF suma uno a los segundos 2 digitos
                        texto2 = string.Format("{0:X2}", part2);//aplica formato haxadecimal al numero sumado
                        Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                        combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                    }
                   else
                    {
                        part2 = 00;//si los segundos 2 digitos son mayores a FF los vuelve a 00
                        texto2 = string.Format("{0:X2}", part2);//aplica formato haxadecimal al numero sumado
                        Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                        combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                        if (part3 < 0xFF)
                        {
                            part3++;//si es menor a FF suma uno a los terceros 2 digitos
                            texto3 = string.Format("{0:X2}", part3);//aplica formato haxadecimal al numero sumado
                            Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                            combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                        }
                        else
                        {
                            part3 = 00;//si los terceros 2 digitos son mayores a FF los vuelve a 00
                            texto3 = string.Format("{0:X2}", part3);//aplica formato haxadecimal al numero sumado
                            Console.WriteLine(texto1 + texto2 + texto3);//imprime la combinacion acutal
                            combinaciones.Add(texto1 + texto2 + texto3 + " - " + TryDecrypt(partkey + texto1 + texto2 + texto3));//intenta desencriptar la combinacion y la agrega a la lista
                        }
                    }
                }
            }
            return combinaciones;//devuelve la lista de con los resultados

        }


        public static string TryDecrypt(string keys)//funcion que hace la desencriptacion
        {
            string encripted = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\resources\DOCUMENTO1.dat");//toma el archivo que intenta desencriptar
            byte[] key;//variable que sera la llave que usara el 3DES
            using (var hashmd5 = new MD5CryptoServiceProvider())
            {
                key = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(keys));//hashing md5 a las llaves
            }
            
            byte[] data = Convert.FromBase64String(encripted);//desconvierte el texto encriptado de base64 a bytes
            using (var tdes = new TripleDESCryptoServiceProvider//crea el proveedor de servicio 3DES
            {
                Key = key,//le asigna la llave a utilizar
                Mode = CipherMode.ECB,//el modo a desencriptar
                Padding = PaddingMode.PKCS7//los saltos que tomara
            })
            using (var transform = tdes.CreateDecryptor())//crea el desencriptador
            {
                try
                {
                    var resultArray = transform.TransformFinalBlock(data, 0, data.Length);//hace la desencriptacion

                    return Encoding.UTF8.GetString(resultArray);//devuelve el texto
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);//escribe un mensaje si hubo un error
                    return string.Empty;//devuelve vacio si se encontro un error
                }
            }
        }

        public static void CreateFile(List<string> contenido,string nombreArchivo)//funcion que crea los archivos
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\resources\"+nombreArchivo+".txt";//donde se guardara el archivo mas el nombre
            try
            {    
                if (File.Exists(fileName))//revisa si existe el archivo
                {
                    File.Delete(fileName);//si existe borra el archivo
                }


                using (FileStream fs = File.Create(fileName))//crea el archivo y lo deja abierto para que se escriban los datos
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes("desencriptado");//titulo
                    fs.Write(title, 0, title.Length);
                    byte[] author = new UTF8Encoding(true).GetBytes("manuel coto");//autor
                    fs.Write(author, 0, author.Length);
                    Console.WriteLine("creo el archivo");//confirma que se creo el archivo
                }

                using (StreamWriter sw = File.CreateText(fileName))//stream para escribir en archivo creado
                {
                    foreach(string line in contenido){//foreach que va en cada item de la lista de contenido que se escribira en el archivo
                        sw.WriteLine(line);//escribe la linea al archivo
                    }
                    Console.WriteLine("termino");//confirma que el archivo a concluido
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());//escribe si se encontro un error
            }
        }
    }
}
