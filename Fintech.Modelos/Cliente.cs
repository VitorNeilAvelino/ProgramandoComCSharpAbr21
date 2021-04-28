using System;
using System.Collections.Generic;

namespace Fintech.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public Endereco Endereco { get; set; }
        public List<Conta> Contas { get; set; }
    }
}