using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooMensagem
{
    internal class Mensagem
    {
        // Atributos
        public string textoMensegem;


        // Métodos
        public void ExibirMensagem()
        {
            Console.WriteLine(this.textoMensegem);
        }
    }
}
