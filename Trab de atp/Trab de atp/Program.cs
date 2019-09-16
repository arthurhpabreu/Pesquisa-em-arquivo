using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trab_de_atp
{
    class Program
    {
        //Declaraçao de Struct
        public struct Contato
        {
            public string email, telefone, nome,idade;
        }
        //contar quantidade de usuarios dentro dos dois arquivos
        public static int contaarquivos()
        {
            StreamReader facebook = new StreamReader("Facebook.txt");
            StreamReader twitter = new StreamReader("Twitter.txt");

            int contador = 0;
            int contador2 = 0;
            while (!facebook.EndOfStream)
            {
                facebook.ReadLine();
                contador = contador + 1;
            }
            while (!twitter.EndOfStream)
            {
                twitter.ReadLine();
                contador2 = contador2 + 1;
            }
            int numerofacetwitter = (contador2 / 4) + (contador / 4);
            facebook.Close();
            twitter.Close();
            return numerofacetwitter;

        }
        //preencher vetor de struct
        public static void preencheVetor(Contato[] Vetor)
        {
            StreamReader facebook = new StreamReader("Facebook.txt");
            StreamReader twitter = new StreamReader("Twitter.txt");
            String linha = "";
            int contador = 0;
            while (!facebook.EndOfStream)
            {
                linha = facebook.ReadLine();
                Vetor[contador].nome = linha;
                linha = facebook.ReadLine();
                Vetor[contador].idade = linha;
                linha = facebook.ReadLine();
                Vetor[contador].email = linha;
                linha = facebook.ReadLine();
                Vetor[contador].telefone = linha;
                contador = contador + 1;
            }
            while (!twitter.EndOfStream)
            {
                linha = twitter.ReadLine();
                Vetor[contador].nome = linha;
                linha = twitter.ReadLine();
                Vetor[contador].idade = linha;
                linha = twitter.ReadLine();
                Vetor[contador].email = linha;
                linha = twitter.ReadLine();
                Vetor[contador].telefone = linha;
                contador = contador + 1;
            }
        }
        //colocar nomes em ordem alfabetica
        public static void ordenarAlfabetica(Contato[] vetor, Contato[] contatos)
        {
            StreamReader facebook = new StreamReader("Facebook.txt");
            StreamReader twitter = new StreamReader("Twitter.txt");
            String Linha;
            int contador = 0;
            string nome;
            while (!facebook.EndOfStream)
            {
                Linha = facebook.ReadLine();
                contatos[contador].nome = Linha;
                Linha = facebook.ReadLine();
                Linha = facebook.ReadLine();
                Linha = facebook.ReadLine();
                contador = contador + 1;
            }
            while (!twitter.EndOfStream)
            {
                Linha = twitter.ReadLine();
                contatos[contador].nome = Linha;
                Linha = twitter.ReadLine();
                Linha = twitter.ReadLine();
                Linha = twitter.ReadLine();
                contador = contador + 1;
            }

            for (int i = 0; i <= (contaarquivos() - 2); i++)
            {
                for (int j = i + 1; j <= (contaarquivos() - 1); j++)
                {
                    //comando para colocar em ordem alfabetica
                    if (String.CompareOrdinal(contatos[i].nome, contatos[j].nome) > 0)
                    {
                        nome = contatos[i].nome;
                        contatos[i].nome = contatos[j].nome;
                        contatos[j].nome = nome;
                    }
                }

            
            }
            for (int y = 0; y < contaarquivos(); y++)
            {
                for (int x = 0; x < contaarquivos(); x++)
                {
                    if(vetor[y].nome == contatos[x].nome)
                    {
                        contatos[x].idade = vetor[y].idade;
                        contatos[x].email = vetor[y].email;
                        contatos[x].telefone = vetor[y].telefone;
                    }
                }
            }
        }
        //retirar repetidos
        public static void retirarRepetidos(Contato[] vetor, Contato[] contatos)
        {
            int contador = 0;

            for (int i = 0; i < contaarquivos(); i++)
            {
                vetor[i] = contatos[i];
            }

            for (int i = 0; i < contaarquivos(); i++)
            {
                for (int n = 0; n < contaarquivos(); n++)
                {
                    if (contatos[i].nome == vetor[n].nome)
                    {
                        contador++;
                    }
                    else contador = 0; 

                    if (contador == 2)
                    {
                        contatos[i].nome = null;
                        contatos[i].idade = null;
                        contatos[i].email = null;
                        contatos[i].telefone = null;
                        contador = 0;
                        i++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //declarar vetores struct
            Contato[] contatos = new Contato[contaarquivos()];
            Contato[] Pessoas = new Contato[contaarquivos()];
            preencheVetor(Pessoas);
            string[] vetor = new string[contaarquivos()];
            ordenarAlfabetica(Pessoas,contatos);
            retirarRepetidos(Pessoas, contatos);

            StreamWriter respostas = new StreamWriter("Contatos.txt");

            for (int x = 0; x < contaarquivos(); x++)
            {
                if (contatos[x].nome != null)
                {
                    respostas.WriteLine(contatos[x].nome);
                    respostas.WriteLine(contatos[x].idade);
                    respostas.WriteLine(contatos[x].email);
                    respostas.WriteLine(contatos[x].telefone);
                }                
            }

            respostas.Close();

            string nome;
            //pesquisa um nome no vetor
            Console.Write(" Digite o nome procurado: ");
            nome = Console.ReadLine();

            for (int i = 0; i < contaarquivos(); i++)
            {
                if (nome == contatos[i].nome)
                {
                    Console.WriteLine(contatos[i].nome);
                    Console.WriteLine(contatos[i].idade);
                    Console.WriteLine(contatos[i].email);
                    Console.WriteLine(contatos[i].telefone);
                }
            }
            Console.ReadKey();
        }
    }
}
