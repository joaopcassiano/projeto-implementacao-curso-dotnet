using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEtapa2
{
    internal class Pessoa {
        public Pessoa()
        {

        }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public void Desconstrutor(out string nome,out string sobrenome)
        {
            nome = Nome;
            sobrenome = Sobrenome;
        }

        private string _nome;
        public string Nome 
        {
            get
            {
                return _nome;
            }

            set
            {
                if (value == "")
                {
                    Console.WriteLine("O nome não pode ser vazio.");
                }
                else
                    _nome = value;
            } 
        }

        private int _idade;
        public int Idade
        {
            get
            {
                return _idade;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("A idade não pode ser menor que 0.");
                }
                else
                    _idade = value;
            }
        }
        public string Sobrenome{ get; set; }
        public string NomeCompleto => $"{Nome} {Sobrenome} = Mensalidade: {Mensalidade:C}";
        public double Mensalidade { get; set; }
        public void CadastraPessoa()
        {
            Console.WriteLine("Digite seu nome:");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite seu sobrenome:");
            Sobrenome = Console.ReadLine();
            Console.WriteLine("Digite sua idade:");
            Idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da sua mensalidade:");
            Mensalidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Horário do cadastro:");
            DateTime data = DateTime.Now;
            Console.WriteLine(data.ToString("dd/MM/yy HH/mm"));
        }
        public void MostrarPessoa()
        {
            Console.WriteLine($"\nPessoa cadastrada com sucesso!\nNome: {NomeCompleto.ToUpper()}\nIdade: {Idade}\nMensalidade: {Mensalidade:C}");
        }

    }
}
