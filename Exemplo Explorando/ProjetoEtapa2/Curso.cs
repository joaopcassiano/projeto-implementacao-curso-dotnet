using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEtapa2
{
    internal class Curso
    {
        public string Nome { get; set; }
        public List<Pessoa> Alunos { get; set; }

        public void AdicionarAluno(Pessoa aluno)
        {
            Alunos.Add(aluno);
        }
        public bool RemoverAluno(Pessoa aluno)
        {
            Alunos.Remove(aluno);
            return Alunos.Remove(aluno);
        }
        public int AlunosMatriculados()
        {
            int quantidade = Alunos.Count;

            return quantidade;
        }
        public void ListarAlunos()
        {
            Console.WriteLine($"\nAlunos matriculados no curso de {Nome}");

            for (int contador = 0; contador < Alunos.Count; contador++)
            {
                int exibicao = contador + 1;
                string texto = "";
                texto = $"\nNº{exibicao} - {Alunos[contador].NomeCompleto}";
                Console.WriteLine(texto);
            }
        }
    }
}
