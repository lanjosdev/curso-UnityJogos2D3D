using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMatematico
{
    internal class Program
    {
        // FUNÇÕES
        static void ExibirMenu() //quando não coloca nada antes do static, tipo 'public', significa q é 'privado'
        {
            Console.Clear();
            Console.WriteLine("|--------- SISTEMA MATEMATICO ---------|");
            Console.WriteLine("(1) Calcular fatorial;");
            Console.WriteLine("(2) Verificar se um número é primo;");
            Console.WriteLine("(3) Efetuar a divisão de um número inteiro;");
            Console.WriteLine("(4) SAIR;");

            Console.WriteLine();
            Console.Write("Opção: ");
        }

        static int CalcularFatorial(int num)
        {
            if(num == 0) return 1;

            int fatorial = num;

            for(int i = num-1; i > 0; i--)
            {
                fatorial = fatorial * i;
            }

            return fatorial;
        }

        static string VerificaNumPrimo(int num)
        {
            int count = 0;

            for(int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }

            if(count == 2)
            {
                return "O número informado é um NÚMERO PRIMO!";
            }             
            else          
            {             
                return "O número informado NÃO é um Número Primo.";
            }
        }

        /*static int CalcularDivisao(int num1, int num2)
        {
            return num1 / num2; 
        }*/
        static void CalcularDivisao(int num1, int num2, out int quociente)
        {
            quociente = num1 / num2;
        }

        
        static void Main(string[] args)
        {
            // VARIAVEIS:
            int opcao = 0;
            int n1, n2, fatorial, quociente;


            // INICIO:
            while(opcao != 4)
            {
                ExibirMenu();
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        // CHAMA FATORIAL
                        Console.WriteLine("|--------- Calcular Fatorial ---------|");
                        Console.Write("Entre com um número: ");
                        n1 = int.Parse(Console.ReadLine());

                        fatorial = CalcularFatorial(n1);
                        Console.WriteLine("O fatorial de {0}! é: {1}", n1, fatorial);
                        break;
                    case 2:
                        // CHAMA PRIMO
                        Console.WriteLine("|--------- Verificar Número Primo ---------|");
                        Console.Write("Entre com um número: ");
                        n1 = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine(VerificaNumPrimo(n1));
                        break;
                    case 3:
                        // CHAMA DIVISAO
                        Console.WriteLine("|--------- Calcular Divisão ---------|");
                        Console.Write("Entre com o dividendo: ");
                        n1 = int.Parse(Console.ReadLine());
                        Console.Write("Entre com o divisor: ");
                        n2 = int.Parse(Console.ReadLine());

                        if (n2 == 0)
                        {
                            Console.WriteLine("Não é possivel o cálculo!");
                        }
                        else
                        {
                            CalcularDivisao(n1, n2, out quociente);
                            Console.WriteLine("A divisão de {0} por {1} é igual a: {2}", n1, n2, quociente);
                        }
                        break;
                    case 4:
                        // SAIR
                        Console.WriteLine("O progrma foi encerrado... Até logo!");
                        break;
                    default:
                        // OPCAO INVALIDA
                        Console.WriteLine("Opção Invalida! Aperte qualquer tecla p/ voltar ao MENU."); 
                        break;
                }
                if(opcao != 4)
                    Console.ReadKey();
            }

        }
    }
}
