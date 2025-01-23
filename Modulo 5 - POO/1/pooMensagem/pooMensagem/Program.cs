using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pooMensagem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Variaveis
            //Mensagem msg1, msg2;
            SegundaMensagem msg3;


            // Aula 51 - Minha primeira classe:
            /*msg1 = new Mensagem(); //Instancia um objeto
            msg1.textoMensegem = "Mensagem 1";
            msg1.ExibirMensagem();

            msg2 = new Mensagem(); //Instancia um objeto
            msg2.textoMensegem = "Mensagem 2";
            msg2.ExibirMensagem();*/


            // Aula 52 - Encapsulamento e métodos de acesso:
            msg3 = new SegundaMensagem();
            msg3.SetTextoMensagem("Lucas");
            Console.WriteLine(msg3.GetTextoMensagem());


            Console.ReadKey();
        }
    }
}
