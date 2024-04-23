using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroPrimo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            string repetir = "s";


            while (repetir == "s")
            {
                Console.WriteLine("PROGRAMA - NÚMERO PRIMO");

                Console.Write("Informe um número inteiro: ");
                num = int.Parse(Console.ReadLine());


                int count = 0;
                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        count++;
                    }
                }
                /*Console.WriteLine(count);*/


                if (count == 2)
                {
                    Console.WriteLine("O valor informado é um NÚMERO PRIMO!");
                }
                else
                {
                    Console.WriteLine("O valor informado NÃO é um Número Primo.");
                }


                Console.WriteLine();
                Console.Write("Deseja repetir o programa? (s/n): ");
                repetir = Console.ReadLine().ToLower();
                Console.Clear();
            }
        }
    }
}
