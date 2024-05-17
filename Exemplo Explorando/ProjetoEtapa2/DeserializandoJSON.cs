using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEtapa2
{
    internal class DeserializandoJSON
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public decimal Salario {  get; set; }
        public DateTime dataConsulta { get; set; }
    }
}
