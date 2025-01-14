using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MeuBichinhoVirtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            - O jogo mantem os dados do bichinho mesmo ao finalizar o game
            - Inicia o programa via prompt de coleta o nome
            - Coleta os dados de alimento, limpo e feliz em um arquivo de texto
            */

            // VARIAVEIS:
            string entrada = "";
            string nome = "";
            string nomeDono = "";

            // Propriedade do bichinho
            float alimentado = 100;
            float higiene = 100;
            float humor = 100;

            // DIMINUI OS VALORES DAS PROPRIEDADES DO BICHINHO:
            int propriedade = 0;
            Random rand = new Random();

            // Dialagos do bichinho:
            string[] dialogos = new string[] {
                "Nossa o dia foi muito legal, comi o sofa!!!",
                "Hoje o dia está lindo lá fora.",
                "Que show da Xuxa é esse???"
            };


            // ENTRADA DE DADOS:    
            Console.WriteLine("MEU BICHINHO VIRTUAL");
            if (args.Length > 0)
            {
                nome = args[0]; // pega o nome no array de args do metodo Main
            }
            else
            {
                // Senao pega por aqui o nome
                Console.Write("Digite o nome do seu Bichinho: ");
                nome = Console.ReadLine();
            }

            Console.Write("Digite seu nome aqui: ");
            nomeDono = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("{0}:", nome);
            Console.WriteLine("Oiiii {0}, estava com muita saudade de você!!!", nomeDono);
            Console.ReadKey();


            // COLETA OS DADOS DO BICHINHO NO ARQUIVO DE TEXTO:
            string dir = Environment.CurrentDirectory + "\\"; //comando que pega o diretorio do executavel deste programa
            string pathFileDb = dir + nome + nomeDono + ".txt";
            if (File.Exists(pathFileDb))
            {
                string[] dados = File.ReadAllLines(pathFileDb);
                alimentado = float.Parse(dados[2]);
                higiene = float.Parse(dados[3]);
                humor = float.Parse(dados[4]);
                if (alimentado <= 0 || higiene <= 0 || humor <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Assistente Virtual:");
                    Console.WriteLine("Seu bichinho está muito fraco...");
                    alimentado = 100;
                    higiene = 100;
                    humor = 100;
                    Thread.Sleep(1800);
                    Console.WriteLine();
                    Console.WriteLine("Pronto, deixamos ele saudável e feliz.");
                    Console.WriteLine("Alimentado: {0}", alimentado);
                    Console.WriteLine("Higiene: {0}", higiene);
                    Console.WriteLine("Humor: {0}", humor);
                    Console.ReadKey();
                }
            }


            // LOOP DO GAME:
            //entrada = "sim";
            while (entrada.ToLower() != "nada" && alimentado > 0 && higiene > 0 && humor > 0)
            {
                // Decrementa as propriedades do bichinho randomicamente (0 - alimentado; 1 - higiene; 2 - humor)
                propriedade = rand.Next(3); // gera um numero aleatorio de 0 até menor q o indicado

                switch (propriedade)
                {
                    case 0: alimentado -= rand.Next(20); break;
                    case 1: higiene -= rand.Next(20); break;
                    case 2: humor -= rand.Next(20); break;
                }


                // Interage com o usuário:
                Console.Clear();
                Console.WriteLine("Alimentado: {0}", alimentado);
                Console.WriteLine("Higiene: {0}", higiene);
                Console.WriteLine("Humor: {0}", humor);

                // Dialogos do bichinho:
                Console.WriteLine();
                Console.WriteLine("{0}:", nome);
                Console.WriteLine(dialogos[rand.Next(dialogos.Length)]);
                Thread.Sleep(2000);

                if (alimentado > 30 && alimentado < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Eu estou faminto!!!!!!");
                    Console.WriteLine("Nada melhor que um lanchinho...");
                    Thread.Sleep(1800);
                }
                if (higiene > 30 && higiene < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nossa estou meio sujinho!!!!!!");
                    Console.WriteLine("Nada melhor que um banho...");
                    Thread.Sleep(1800);
                }
                if (humor > 30 && humor < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aiii que tédio!!!!!!");
                    Console.WriteLine("Queria brincar com alguém...");
                    Thread.Sleep(1800);
                }


                if (alimentado <= 0 || higiene <= 0 || humor <= 0)
                {
                    break;
                }

                Console.Clear();

                Console.WriteLine("O que vamos fazer hoje, {0}?", nomeDono);
                Console.Write("Comer / Banhar / Brincar / Nada: ");
                entrada = Console.ReadLine().ToLower();

                // Incrementa as propriedades do bichinho
                switch (entrada)
                {
                    case "comer": alimentado += rand.Next(30); break;
                    case "banhar": higiene += rand.Next(50); break;
                    case "brincar": humor += rand.Next(30); break;
                }

                if (alimentado > 100) alimentado = 100;
                if (higiene > 100) higiene = 100;
                if (humor > 100) humor = 100;
            }

            
            // MENSAGEM DE SAÍDA DO JOGO:
            Console.Clear();
            if (alimentado <= 0 || higiene <= 0 || humor <= 0)
            {
                Console.WriteLine("{0}, estou muito fraco...", nomeDono);
                Console.WriteLine("Seu bichinho precisa de um assistente virtual :(");
                Console.WriteLine("Nos vemos em breve.");
            }
            else
            {
                Console.WriteLine("Obrigado por cuidar de mim {0}!!!!!", nomeDono);
                Console.WriteLine("Volte logo!!!");
            }

            // ARMAZENA OS DADOS EM UM ARQUIVO DE TEXTO:
            //organize os dados
            string fileContent = nome + Environment.NewLine;
            fileContent += nomeDono + Environment.NewLine;
            fileContent += alimentado + Environment.NewLine;
            fileContent += higiene + Environment.NewLine;
            fileContent += humor + Environment.NewLine;
            //grava os dados no arquivo de texto
            File.WriteAllText(pathFileDb, fileContent);

            Console.ReadKey();
        }
    }
}