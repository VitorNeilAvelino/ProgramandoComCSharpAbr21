using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Modelos
{
    public class ContaEspecial : Conta
    {
        public ContaEspecial()
        {

        }

        public ContaEspecial(Agencia agencia, int numero, string digitoVerificador, decimal limite) 
            : base(agencia, numero, digitoVerificador)
        {
            Limite = limite;
        }

        public decimal Limite { get; set; }

        public Movimento EfetuarOperacao(decimal valor, Operacao operacao)
        {
            return /*base.*/EfetuarOperacao(valor, operacao, Limite);           
        }
    }
}