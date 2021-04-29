using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Modelos
{
    public class Poupanca : Conta
    {
        public Poupanca(Agencia agencia, int numero, string digitoVerificador) 
            : base(agencia, numero, digitoVerificador)
        {
        }

        public decimal TaxaRendimento { get; set; }
    }
}