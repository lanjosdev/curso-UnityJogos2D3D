using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole
{
    internal class Program
    {
        //FUNÇÕES / METODOS:
        static void ExibirMenu(out int op) //static significa que este metodo pertence a esta classe,  no caso a classe 'Program'
        {
            Console.Clear();

            Console.WriteLine("|--------- AGENDA CONSOLE ---------|");
            Console.WriteLine("(1) Exibir todos os contatos;");
            Console.WriteLine("(2) Localizar contato;");
            Console.WriteLine("(3) Inserir novo contato;");
            Console.WriteLine("(4) Alterar contato;");
            Console.WriteLine("(5) Deletar contato;");
            Console.WriteLine();
            Console.WriteLine("(6) SAIR");

            Console.WriteLine();
            Console.Write("Opção: ");
            op = int.Parse(Console.ReadLine());

            Console.Clear();
            //return op;
        }

        static void GetAllContatos(string[] nome, string[] email, int tl) //usa parametros pra pegar variaveis de outro metodo (no caso o metodo 'Main')
        {
            Console.WriteLine("LISTA DE CONTATOS:");

            if(tl == 0)
            {
                Console.WriteLine("Agenda sem contatos!");   
            }
            else
            {
                try
                {
                    for (int i = 0; i < tl; i++)
                    {
                        Console.WriteLine("Nome: {0} - Email: {1}", nome[i], email[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("DEU ERRO: " + ex.Message);
                }
            }

            Console.Write("Aperte qualquer tecla p/ voltar ao MENU.");
            Console.ReadKey();
        }

        static int LocalizarContato(string[] email, int numRegistro, string inputEmail)
        {
            int pos = -1;
            int idx = 0;
            while(idx < numRegistro && email[idx] != inputEmail)
            {
                idx++;
            }
            if(idx < numRegistro) pos = idx;

            return pos;
        }

        static void CreateContato(ref string[] nome, ref string[] email, ref int tl) //ref significa que ira modificar diretamente as variaveis do outro metodo que foram passadas como params neste metodo
        {
            Console.WriteLine("INSERA NOVO CONTATO:");

            try
            {
                if (tl >= 200) {
                    Console.WriteLine("Quantidade máxima de contato já atingida!!!");
                }
                else
                {
                    Console.Write("Digite o nome: ");
                    string nomeCreate = Console.ReadLine();
                    Console.Write("Digite o email: ");
                    string emailCreate = Console.ReadLine();

                    //Verifica se email já esta na agenda:
                    int pos = LocalizarContato(email, tl, emailCreate);
                    if (pos == -1)
                    {
                        nome[tl] = nomeCreate;
                        email[tl] = emailCreate;
                        tl++;

                        Console.Clear();
                        Console.WriteLine("Contato criado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Já existe um contato com este e-mail");
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine("DEU ERRO: " + e.Message);
            }

            Console.Write("Aperte qualquer tecla p/ voltar ao MENU.");
            Console.ReadKey();
        }

        static void UpdateContato(ref string[] nomes, ref string[] emails, ref int numRegistro)
        {
            Console.WriteLine("ALTERAR DADOS DO CONTATO:");

            if(numRegistro == 0)
            {
                Console.WriteLine("Ainda não existem contatos na agenda.");
            }
            else
            {
                try
                {
                    Console.Write("Digite o e-mail do contato que deseja alterar: ");
                    string getEmail = Console.ReadLine();

                    //Faz a localização do contato:
                    int pos = LocalizarContato(emails, numRegistro, getEmail);
                    if (pos != -1)
                    {
                        Console.Clear();
                        Console.WriteLine("Contato encontrado! Agora insira os novos dados:");
                        Console.Write("Novo nome (se não, deixe vazio): ");
                        string newNome = Console.ReadLine();
                        if (newNome != "" && newNome != nomes[pos])
                        {
                            nomes[pos] = newNome;
                        }
                        else
                        {
                            newNome = "";
                        }

                        Console.Write("Novo e-mail (se não, deixe vazio): ");
                        string newEmail = Console.ReadLine();
                        int posAux = -1;
                        if (newEmail != "")
                        {
                            posAux = LocalizarContato(emails, numRegistro, newEmail);
                            if (posAux == -1 || posAux == pos)
                            {
                                emails[pos] = newEmail;
                            }
                            else
                            {
                                Console.WriteLine("Já existe um contato com este e-mail");
                                Console.Write("Aperte qualquer tecla p/ continuar.");
                                Console.ReadKey();
                            }
                        }

                        if (newNome != "" || (newEmail != "" && posAux == -1))
                        {
                            Console.Clear();
                            Console.WriteLine("Contato alterado! Veja os novos dados:");
                            Console.WriteLine("Nome: {0} - Email: {1}", nomes[pos], emails[pos]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Nenhuma alteração foi realizada!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Contato não encontrado");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("DEU ERRO: " + e.Message);
                }
            }

            Console.Write("Aperte qualquer tecla p/ voltar ao MENU.");
            Console.ReadKey();
        }

        static void DeleteContato(ref string[] nomes, ref string[] emails, ref int numRegistro)
        {
            Console.WriteLine("DELETAR UM CONTATO:");

            if (numRegistro == 0)
            {
                Console.WriteLine("Ainda não existem contatos na agenda.");
            }
            else
            {
                Console.Write("Digite o email do contato que deseja deletar: ");
                string emailDel = Console.ReadLine();
                int pos = -1;

                pos = LocalizarContato(emails, numRegistro, emailDel);
                if (pos != -1)
                {
                    Console.WriteLine("Nome: {0} - Email: {1}", nomes[pos], emails[pos]);
                    Console.Write("Deseja deletar o contato acima? (S/N): ");
                    string resDelete = Console.ReadLine();

                    if (resDelete == "s" || resDelete == "S")
                    {
                        try
                        {
                            for (int idx = pos; idx < numRegistro; idx++)
                            {
                                nomes[idx] = nomes[idx + 1];
                                //Console.WriteLine(nomes[idx]);
                                emails[idx] = emails[idx + 1];
                                //Console.WriteLine(emails[idx]);
                            }

                            numRegistro--;

                            Console.Clear();
                            Console.WriteLine("Contato deletado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("DEU ERRO: " + ex.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Contato não encontrado");
                }
            }

            Console.Write("Aperte qualquer tecla p/ voltar ao MENU.");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            //VARIAVEIS:
            string[] nomes = new string[200];
            string[] emails = new string[200];
            int numRegistro = 0;
            int opcao = 0;
            string inputEmail = "";
            int pos;


            //INICIO
            // deve carregar os dados do arquivo txt (nosso db)
            BackupAgenda.dbFile = "dados.txt";
            BackupAgenda.RestoreData(ref nomes, ref emails, ref numRegistro);

            while (opcao != 6)
            {
                ExibirMenu(out opcao);

                switch (opcao)
                {
                    case 1:
                        //Exibir todos os contatos
                        GetAllContatos(nomes, emails, numRegistro);
                        break;
                    case 2:
                        //Localizar contato
                        Console.WriteLine("LOCALIZAR UM CONTATO:");

                        if(numRegistro == 0)
                        {
                            Console.WriteLine("Ainda não existem contatos na agenda.");
                        } 
                        else
                        {
                            Console.Write("Digite o email do contato que deseja buscar: ");
                            inputEmail = Console.ReadLine();

                            pos = LocalizarContato(emails, numRegistro, inputEmail);
                            if (pos != -1)
                            {
                                Console.WriteLine("Nome: {0} - Email: {1}", nomes[pos], emails[pos]);
                            }
                            else
                            {
                                Console.WriteLine("Contato não encontrado");
                            }
                        }

                        Console.Write("Aperte qualquer tecla p/ voltar ao MENU.");
                        Console.ReadKey();
                        break;
                    case 3:
                        //Inserir novo contato
                        CreateContato(ref nomes, ref emails, ref numRegistro);
                        break;
                    case 4:
                        //Alterar contato
                        UpdateContato(ref nomes, ref emails, ref numRegistro);
                        break;
                    case 5:
                        //Deletar contato
                        DeleteContato(ref nomes, ref emails, ref numRegistro);
                        break;
                    case 6:
                        //SAIR
                        Console.WriteLine("O progrma foi encerrado... Até logo!");
                        break;
                    default:
                        //OPCAO INVALIDA
                        Console.WriteLine("Opção Invalida! Aperte qualquer tecla p/ voltar ao MENU.");
                        Console.ReadKey();
                        break;
                }
            }

            //salvar os dados no arquivo txt
            BackupAgenda.SaveData(ref nomes, ref emails, ref numRegistro);
        }
    }
}
