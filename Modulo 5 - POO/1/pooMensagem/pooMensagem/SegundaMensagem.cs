using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooMensagem
{
    internal class SegundaMensagem
    {
        // Atributos
        private string textoMensegem; 
        //colocar "private" é opcional, sem colcar modificador de acesso
        //é a mesma coisade private


        // Métodos
        public void ExibirMensagem()
        {
            Console.WriteLine(this.textoMensegem);
        }

        public string GetTextoMensagem() // método de acesso
        {
            return this.textoMensegem;
        }

        public void SetTextoMensagem(string valor) // método de modificação
        {
            //aqui a classe que manda como vai ser tratado o valor que chega para ser atribuido
            this.textoMensegem = valor.ToUpper(); 
        }
    }
}
