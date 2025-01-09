using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            // VARIAVEIS - ATRIBUTOS:
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
            Console.WriteLine("Oiiii {0}, estava com muita saudade de você!!!", nomeDono);
            Console.ReadKey();


            // COLETA OS DADOS DO BICHINHO NO ARQUIVO DE TEXTO (AINDA SERÁ GEREADO)


            // LOOP DO GAME:
            //entrada = "sim";
            while (entrada.ToLower() != "nada") 
            {
                // Altera as propriedades do bichinho randomicamente (0 - alimentado; 1 - higiene; 2 - humor)
                propriedade = rand.Next(3); // gera um numero aleatorio de 0 até menor q o indicado

                switch (propriedade)
                {
                    case 0: alimentado -= rand.Next(20); break;
                    case 1: higiene -= rand.Next(20); break;
                    case 2: humor -= rand.Next(20); break;
                }


                // Interage com o usuário:
                Console.Clear();
                //Console.WriteLine("Oiiii {0}, estava com muita saudade de você!!!", nomeDono);
                Console.WriteLine("Alimentado: {0}", alimentado);
                Console.WriteLine("Higiene: {0}", higiene);
                Console.WriteLine("Humor: {0}", humor);

                if(alimentado > 40 && alimentado < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Eu estou faminto!!!!!!");
                    Console.WriteLine("Nada melhor que um lanchinho...");
                }
                if (higiene > 40 && higiene < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nossa estou meio sujinho!!!!!!");
                    Console.WriteLine("Nada melhor que um banho...");
                }
                if (humor > 40 && humor < 60)
                {
                    Console.WriteLine();
                    Console.WriteLine("Aiii que tédio!!!!!!");
                    Console.WriteLine("Queria brincar com alguém...");
                }

                Console.WriteLine();
                Console.WriteLine("O que vamos fazer hoje, {0}?", nomeDono);
                Console.Write("Comer / Banhar / Brincar / Nada: ");
                entrada = Console.ReadLine().ToLower();

                switch(entrada)
                {
                    case "comer": alimentado += rand.Next(30); break;
                    case "banhar": higiene += rand.Next(50); break;
                    case "brincar": humor += rand.Next(30); break;
                }

                if(alimentado > 100) alimentado = 100;
                if(higiene > 100) higiene = 100;
                if(humor > 100) humor = 100;
            }

            // MENSAGEM DE SAÍDA:
            Console.Clear();
            Console.WriteLine("Obrigado por cuidar do seu bichinho!!!!!");
            Console.ReadKey();
        }
    }
}
