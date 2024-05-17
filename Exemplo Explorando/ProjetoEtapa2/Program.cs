using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Collections.Specialized;
using System.CodeDom;
using Newtonsoft.Json;

namespace ProjetoEtapa2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
                int op = 0;

                Console.WriteLine("Bem vindo! Aqui vai uma breve apresentação do diretor da nossa universidade!\n");

                (int colocacao, string nome, string sobrenome, double nota) tupla = (1, "Paulo Henrique", "Krav Magá", 9.78);
                //ValueTuple<int, string, string, double> outroExemploTupla = (1, "Paulo Henrique", "Krav Magá", 9.78);  // Outra forma de criar Tupla.
                //var outroExemploTuplaCreate = Tuple.Create(1, "Paulo Henrique", "Krav Magá", 9.78);                    // Outra forma de criar Tupla.

                Console.WriteLine($"Nº {tupla.colocacao} da cidade!");
                Console.WriteLine($"Nome: {tupla.nome}");
                Console.WriteLine($"Sobrenome: {tupla.sobrenome}");
                Console.WriteLine($"Nota Universidade: {tupla.nota}");
                Console.WriteLine("\nPara prosseguir pressione qualquer tecla!");
                Console.ReadKey();
                Console.Clear();

                Pessoa pessoa1 = new Pessoa();
                pessoa1.CadastraPessoa();
                pessoa1.MostrarPessoa();
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                Pessoa pessoa2 = new Pessoa();
                pessoa2.CadastraPessoa();
                pessoa2.MostrarPessoa();
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();

                Curso curso = new Curso();
                Console.WriteLine("Digite o nome do curso:");
                curso.Nome = Console.ReadLine();
                curso.Alunos = new List<Pessoa>();
                curso.AdicionarAluno(pessoa1);
                curso.AdicionarAluno(pessoa2);
                Console.Clear();
                curso.ListarAlunos();
                Console.WriteLine("\nPressione qualquer tecla para abrir a base salarial da profissão de CiÊncia da Computação");
                Console.ReadKey();
                Console.Clear();

                DateTime dataConsulta = DateTime.Now;
                List<Venda> listaVendas = new List<Venda>();
                Venda v1 = new Venda(1, "Base salarial júnior", 2300.00M, dataConsulta);
                Venda v2 = new Venda(2, "Base salarial pleno", 6059.00M, dataConsulta);
                Venda v3 = new Venda(3, "Base salarial senior", 14981.00M, dataConsulta);
                listaVendas.Add(v1);
                listaVendas.Add(v2);
                listaVendas.Add(v3);
                string serializado = JsonConvert.SerializeObject(listaVendas, Formatting.Indented);
                File.WriteAllText("Arquivos/vendas.json", serializado);
                Console.WriteLine(serializado);
                Console.ReadKey();
                Console.Clear();

                Dictionary<string, string> estados = new Dictionary<string, string>();

                Console.WriteLine("Estados em que o curso está disponível:\n");
                estados.Add("MG", "Minas Gerais");
                estados.Add("SP", "Sao Paulo");
                estados.Add("RJ", "Rio de Janeiro");
                foreach(var item  in estados)
                {
                    Console.WriteLine($"{item.Key} - {item.Value} ");
                }
                Console.WriteLine("\nRemovendo RJ por indisponibilidade e adicionando ~ em SP:\n");
                estados.Remove("RJ");
                estados["SP"] = "São Paulo";
                foreach (var item in estados)
                {
                    Console.WriteLine($"{item.Key} - {item.Value} ");
                }
                string chave = "MG";
                Console.WriteLine($"\nVerificando elemento: {chave}\n");
                if (estados.ContainsKey(chave))
                {
                    Console.WriteLine("Valor existente");
                }
                else
                {
                    Console.WriteLine($"É seguro adicionar a chave {chave}");
                }
                Console.WriteLine("Pressione qualquer tecla para prosseguir");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Pessoas que ainda faltam cadastrar(utilizando filas):\n");
                Queue<string> fila = new Queue<string>();
                fila.Enqueue("Isabelly");
                fila.Enqueue("Marcus");
                fila.Enqueue("Pedro Lucas");
                foreach (string item in fila)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nRemovendo {fila.Dequeue()}:\n");
                foreach (string item in fila)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Pressione qualquer tecla para prosseguir");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("Pessoas que ainda faltam cadastrar (utilizando pilhas):\n");
                Stack<string> pilha = new Stack<string>();
                pilha.Push("Isabelly");
                pilha.Push("Marcus");
                pilha.Push("Pedro Lucas");
                foreach (string item in pilha)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"\nRemovendo {pilha.Pop()}:\n");
                foreach (string item in pilha)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Pressione qualquer tecla para prosseguir");
                Console.ReadKey();
                Console.Clear();

                string[] linhas = File.ReadAllLines("Arquivos/ArquivoTexto.txt"); // Lendo arquivo TXT externo.
                Console.WriteLine("Para mostrar o conteúdo do programa, digite 1, para sair digite 2.");
                op = int.Parse(Console.ReadLine());
                Console.Clear();
                if (op == 1)
                {
                    foreach (string linha in linhas)
                    {
                        Console.WriteLine(linha);
                    }
                }
                Console.ReadKey();
                Console.Clear();

                LeituraArquivo arquivo = new LeituraArquivo();
                var (Sucesso, Linhas, QuantidadeLinhas) = arquivo.LerArquivo("Arquivos/ArquivoTexto.txt");
                Console.WriteLine("Pressione qualquer tecla para mostrar o conteúdo (utilizando tupla):");
                Console.ReadKey();
                if (Sucesso)
                {
                    Console.WriteLine($"Quantidade linhas arquivo: {QuantidadeLinhas}");
                    foreach (string linha in Linhas)
                    {
                        Console.WriteLine(linha);
                    }
                }
                else
                {
                    Console.WriteLine("Não foi possível ler o arquivo:");
                }
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu uma excessão genérica.\n{ex.Message}");
                Console.ReadKey();
            }
            finally
            {
                Console.Clear();
                Console.WriteLine("Obrigado por utilizar o programa. Pressione qualquer tecla para sair");
                Console.ReadKey();
            }
        }
    }
}