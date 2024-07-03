using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal class Program
    {
        // Funções:
        static void LerArquivo(string arquivo)
        {
            try
            {
                string linha = "";
                StreamReader sr = new StreamReader(arquivo);

                linha = sr.ReadLine();
                while(linha != null)
                {
                    Console.WriteLine(linha);
                    linha = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception e) {
                Console.WriteLine("DEU ERRO: Arquivo em branco ou não existe");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
        static int ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("|--------- EDITOR DE TEXTO ---------|");
            Console.WriteLine("(1) Abrir/criar um arquivo;");
            Console.WriteLine("(2) Exibir texto do arquivo;");
            Console.WriteLine("(3) Gravar um texto no arquivo;");
            Console.WriteLine("(4) Gravar um novo texto no arquivo;");
            Console.WriteLine("(5) SAIR");

            Console.WriteLine();
            Console.Write("Opção: ");
            int op = int.Parse(Console.ReadLine());

            return op;
        }


        // Principal:
        static void Main(string[] args)
        {
            //Objetivos:
            //1 - Abrir um arquivo
            //2 - Exibir o texto
            //3 - Editar adicionando texto ou criando um texto do zero

            // Variaveis:
            int opcao = 0;
            string arquivo = "";

            // INICIO:
            while (opcao != 5)
            {
                opcao = ExibirMenu();
                Console.Clear();

                switch(opcao)
                {
                    case 1:
                        //Abrir/criar um arquivo
                        Console.Write("Informe o nome do arquivo: ");
                        arquivo = Console.ReadLine();
                        break;
                    case 2:
                        //Exibir texto do arquivo
                        LerArquivo(arquivo);
                        break;
                }
            }
        }
    }
}
