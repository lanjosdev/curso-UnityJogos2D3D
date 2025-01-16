using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MeuBichinhoVirtual
{
    internal class Program
    {
        // imagem modo texto
        static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            // Cria um novo Bitmap com a largura e altura desejadas
            Bitmap resizedImage = new Bitmap(width, height);

            // Desenha a imagem original no novo Bitmap usando as dimensões desejadas
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        static string ConvertToAscii(Bitmap image)
        {
            // Caracteres ASCII usados para representar a imagem
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };

            StringBuilder asciiArt = new StringBuilder();

            // Percorre os pixels da imagem e converte cada um em um caractere ASCII correspondente
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int asciiIndex = grayScale * (asciiChars.Length - 1) / 255;
                    char asciiChar = asciiChars[asciiIndex];
                    asciiArt.Append(asciiChar);
                }
                asciiArt.Append(Environment.NewLine);
            }

            return asciiArt.ToString();
        }

        static void ExibirImagem(string imagePath, int width, int height)
        {
            // Caminho para a imagem que deseja exibir
            //string imagePath = @"C:\Users\Danilo Filitto\Downloads\Panda.jpg";

            // Carrega a imagem
            Bitmap image = new Bitmap(imagePath);

            // Redimensiona a imagem para a largura e altura desejadas
            int consoleWidth = width;
            int consoleHeight = height;
            Bitmap resizedImage = ResizeImage(image, consoleWidth, consoleHeight);

            // Converte a imagem em texto ASCII
            string asciiArt = ConvertToAscii(resizedImage);

            // Exibe o texto ASCII no console
            Console.WriteLine(asciiArt);
        }
        // imagem modo texto


        static void InputDatasUser(ref string nome, ref string nomeDono)
        {
            Console.Write("Digite o nome do seu Bichinho: ");
            nome = Console.ReadLine();
            Console.Write("Digite seu nome aqui: ");
            nomeDono = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Olá {0}, o seu bichinho virtual é o(a) {1}!", nomeDono, nome);
            Console.ReadKey();
        }

        static void SaveFileDb(string nome, string nomeDono, float alimentado, float higiene, float humor) 
        {
            //organize os dados
            string fileContent = nome + Environment.NewLine;
            fileContent += nomeDono + Environment.NewLine;
            fileContent += alimentado + Environment.NewLine;
            fileContent += higiene + Environment.NewLine;
            fileContent += humor + Environment.NewLine;
            //grava os dados no arquivo de texto
            string dir = Environment.CurrentDirectory + "\\"; //comando que pega o diretorio do executavel deste programa
            string pathFileDb = dir + nome + nomeDono + ".txt";
            File.WriteAllText(pathFileDb, fileContent);
        }

        static void ReadFileDb(string nome, string nomeDono, ref float alimentado, ref float higiene, ref float humor) 
        {
            string dir = Environment.CurrentDirectory + "\\"; //comando que pega o diretorio do executavel deste programa
            string pathFileDb = dir + nome + nomeDono + ".txt";
            if (File.Exists(pathFileDb))
            {
                string[] dados = File.ReadAllLines(pathFileDb);
                alimentado = float.Parse(dados[2]);
                higiene = float.Parse(dados[3]);
                humor = float.Parse(dados[4]);
                if (alimentado <= 0 || higiene <= 0 || humor <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Assistente Virtual:");
                    Console.WriteLine("Seu bichinho está muito fraco...");
                    alimentado = 100;
                    higiene = 100;
                    humor = 100;
                    Thread.Sleep(1800);
                    Console.WriteLine();
                    Console.WriteLine("Pronto, deixamos ele saudável e feliz.");
                    Console.WriteLine("Alimentado: {0}", alimentado);
                    Console.WriteLine("Higiene: {0}", higiene);
                    Console.WriteLine("Humor: {0}", humor);
                    Console.ReadKey();
                }
            }
        }

        static void Speaks(int tipo, float alimentado, float higiene, float humor) 
        {
            // Dialagos do bichinho:
            switch(tipo)
            {
                case 0:
                    string[] dialogos = new string[] {
                        "Nossa o dia foi muito legal, comi o sofa!!!",
                        "Hoje o dia está lindo lá fora.",
                        "Que show da Xuxa é esse???"
                    };

                    Random rand = new Random();
                    Console.WriteLine(dialogos[rand.Next(dialogos.Length)]);
                    break;
                case 1:
                    if (alimentado > 30 && alimentado < 60)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Eu estou faminto!!!!!!");
                        Console.WriteLine("Nada melhor que um lanchinho...");
                        Thread.Sleep(1800);
                    }
                    if (higiene > 30 && higiene < 60)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nossa estou meio sujinho!!!!!!");
                        Console.WriteLine("Nada melhor que um banho...");
                        Thread.Sleep(1800);
                    }
                    if (humor > 30 && humor < 60)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Aiii que tédio!!!!!!");
                        Console.WriteLine("Queria brincar com alguém...");
                        Thread.Sleep(1800);
                    }
                    break;
            }
        }

        static void DecrementProperties(ref float alimentado, ref float higiene, ref float humor)
        {
            // DIMINUI OS VALORES DAS PROPRIEDADES DO BICHINHO:
            Random rand = new Random();
            int propriedade = rand.Next(3); // gera um numero aleatorio de 0 até menor q o indicado

            switch (propriedade)
            {
                case 0: alimentado -= rand.Next(20); break;
                case 1: higiene -= rand.Next(20); break;
                case 2: humor -= rand.Next(20); break;
            }
        }

        static void Interact(string nomeDono, ref string entrada, ref float alimentado, ref float higiene, ref float humor) {
            Random rand = new Random();
            Console.WriteLine("O que vamos fazer hoje, {0}?", nomeDono);
            Console.Write("Comer / Banhar / Brincar / Nada: ");
            entrada = Console.ReadLine().ToLower();

            // Incrementa as propriedades do bichinho
            switch (entrada)
            {
                case "comer": alimentado += rand.Next(30); break;
                case "banhar": higiene += rand.Next(50); break;
                case "brincar": humor += rand.Next(30); break;
            }

            if (alimentado > 100) alimentado = 100;
            if (higiene > 100) higiene = 100;
            if (humor > 100) humor = 100;
        }




        static void Main(string[] args)
        {
            /*
            - O jogo mantem os dados do bichinho mesmo ao finalizar o game
            - Inicia o programa via prompt de coleta o nome
            - Coleta os dados de alimento, limpo e feliz em um arquivo de texto
            */

            // VARIAVEIS:
            string entrada = "";
            string nome = "";
            string nomeDono = "";
            // Imagem do bichinho
            string pathPhoto = Environment.CurrentDirectory + "\\pikachu.jpg";
            // Propriedade do bichinho
            float alimentado = 100;
            float higiene = 100;
            float humor = 100;


            // EXIBIÇÃO INICIAL:
            if (File.Exists(pathPhoto)) { 
                ExibirImagem(pathPhoto, 35, 25);
            }
            Console.WriteLine("MEU BICHINHO VIRTUAL");

            // ENTRADA DE DADOS (nomes):  
            if (args.Length > 0)
            {
                nome = args[0]; // pega o nome no array de args do metodo Main
                Console.Write("Digite seu nome aqui: ");
                nomeDono = Console.ReadLine();

                Console.WriteLine();
                //Console.WriteLine("{0}:", nome);
                Console.WriteLine("Olá {0}, o seu bichinho virtual é o(a) {1}!", nomeDono, nome);
                Console.ReadKey();
            }
            else
            {
                // Senao pega por aqui o nome
                InputDatasUser(ref nome, ref nomeDono);
            }

            // COLETA OS DADOS DO BICHINHO NO ARQUIVO DE TEXTO:
            ReadFileDb(nome, nomeDono, ref alimentado, ref higiene, ref humor);


            // LOOP DO GAME:
            while (entrada.ToLower() != "nada" && alimentado > 0 && higiene > 0 && humor > 0)
            {
                // Decrementa as propriedades do bichinho randomicamente (0 - alimentado; 1 - higiene; 2 - humor)
                DecrementProperties(ref alimentado, ref higiene, ref humor);

                // Status do bichinho
                Console.Clear();
                Console.WriteLine("Alimentado: {0}", alimentado);
                Console.WriteLine("Higiene: {0}", higiene);
                Console.WriteLine("Humor: {0}", humor);
                // Status do bichinho

                // Dialogos do bichinho
                Console.WriteLine();
                Console.WriteLine("{0}:", nome);
                Speaks(0, 0, 0, 0);
                Thread.Sleep(2000);
                Speaks(1, alimentado, higiene, humor);
                // Dialogos do bichinho

                if (alimentado <= 0 || higiene <= 0 || humor <= 0)
                {
                    break;
                }

                // Interação com bichinho:
                Console.Clear();
                Interact(nomeDono, ref entrada, ref alimentado, ref higiene, ref humor);
            }


            // MENSAGEM DE SAÍDA DO JOGO:
            Console.Clear();
            if (alimentado <= 0 || higiene <= 0 || humor <= 0)
            {
                Console.WriteLine("{0}, estou muito fraco...", nomeDono);
                Console.WriteLine("Seu bichinho precisa de um assistente virtual :(");
                Console.WriteLine("Nos vemos em breve.");
            }
            else
            {
                Console.WriteLine("Obrigado por cuidar de mim {0}!!!!!", nomeDono);
                Console.WriteLine("Volte logo!!!");
            }

            // ARMAZENA OS DADOS EM UM ARQUIVO DE TEXTO:
            SaveFileDb(nome, nomeDono, alimentado, higiene, humor);

            Console.ReadKey();
        }
    }
}