﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEtapa2
{
    internal class LeituraArquivo
    {
        public (bool Sucesso, string[] Linhas, int QuantidadeLinhas) LerArquivo(string caminho)
        {
            try
            {
                string[] linhas = File.ReadAllLines(caminho);
                return (true, linhas, linhas.Count());
            }catch (Exception ex)
            {
                return (false, new string[0], 0);
            }
        }
    }
}
