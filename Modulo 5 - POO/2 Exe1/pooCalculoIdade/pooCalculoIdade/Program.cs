using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooCalculoIdade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PROGRAMA QUE CALCULA A IDADE DE UMA PESSOA");

            Console.WriteLine();
            Pessoa p = new Pessoa();

            Console.Write("Nome da pessoa: ");
            p.Nome = Console.ReadLine();
            Console.Write("Ano de nascimento da pesssoa: ");
            p.AnoNascimento = Convert.ToInt32(Console.ReadLine());

            p.ExibirDados();
            Console.ReadKey();
        }
    }
}
