using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // VARIAVEIS:
            string[] perguntas = {
                "\"O que tem capa mas não voa?\"",
                "\"Sem sair do seu cantinho, é capaz de viajar ao redor do mundo?\"",
                "\"É alta quando jovem e baixinha quando fica velha. Além disso, é rápida quando é magra e lenta quando é gorda?\""
            };
            string[] respostas = {
                "Livro",
                "Selo",
                "Vela"
            };
            string respostaUser = "";
            int idx = 0;
            string sair = "";


            // INICIO:
            while (sair != "q")
            {
                // Pergunta randomica:
                Random rand = new Random();
                idx = rand.Next(0, respostas.Length); //intervalo de 0..tamanho-1
                Console.WriteLine("Pergunta: {0}", perguntas[idx]);

                Console.Write("Resposta: ");
                respostaUser = Console.ReadLine();
                Console.WriteLine();


                // Processamento:
                if(respostaUser.ToLower() == respostas[idx].ToLower())
                {
                    Console.WriteLine("Parabens!!!! Você Acertou!");
                }
                else
                {
                    Console.WriteLine("Que pena :( Você errou!!!!");
                }


                Console.WriteLine();
                Console.Write("Pressione q/ tecla para tentar novamente OU \"q\" p/ sair: ");
                sair = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }
    }
}
