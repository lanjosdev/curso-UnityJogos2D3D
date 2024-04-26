using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string arquivo = args[0]; // arquivo que vem como argumento OU path completo
            string linha = "";

            try
            {
                StreamReader sr = new StreamReader(arquivo);
                linha = sr.ReadLine(); // le linha do arquivo e salva na variavel;

                while (linha != null)
                {
                    Console.WriteLine(linha);
                    linha = sr.ReadLine();
                }

                /*do {
                    linha = sr.ReadLine(); // le linha do arquivo e salva na variavel;

                    Console.WriteLine(linha);
                } while(linha != null);*/

                sr.Close(); //Fecha o arquivo depois q leu tudo
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algum erro: " + ex.Message);
            }
        }
    }
}
