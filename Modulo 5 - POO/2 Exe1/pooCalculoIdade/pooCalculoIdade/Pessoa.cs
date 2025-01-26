using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooCalculoIdade
{
    internal class Pessoa
    {
        // PROPRIEDADES
        private string nome;
        public string Nome
        { 
            get { return this.nome; } 
            set { this.nome = value.ToUpper(); }
        }

        private int anoNascimento;
        public int AnoNascimento
        {  
            get { return this.anoNascimento; } 
            set { this.anoNascimento = value; }
        }


        // MÉTODOS / AÇÕES
        private int CalcularIdade()
        {
            DateTime data = DateTime.Now;
            int anoAtual = data.Year;

            int idade = anoAtual - this.AnoNascimento;
            return idade;
        }

        public void ExibirDados()
        {
            Console.WriteLine();
            Console.WriteLine("DADOS DA PESSOA:");
            Console.WriteLine("Nome: {0}", this.Nome);
            Console.WriteLine("Ano de nascimento: {0}", this.AnoNascimento);

            Console.WriteLine();
            int idade = this.CalcularIdade();
            Console.WriteLine("A idade de {0} é: {1}", this.Nome, idade);
        }
    }
}
