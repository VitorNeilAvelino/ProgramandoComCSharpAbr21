using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo10.DelegatesLambda.Testes
{
    internal delegate int EfetuarOperacao(int valor1, int valor2);
    static class Calculadora
    {
        //TODO: OO - private - Encapsulamento.
        private static int Somar(int x, int y)
        {
            return x + y;
        }

        private static int Subtrair(int x, int y)
        {
            return x - y;
        }

        private static int Multiplicar(int x, int y, int z)
        {
            return x * y * z;
        }

        public static EfetuarOperacao ObterOperacao(TipoOperacao tipoOperacao)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Soma:
                    return Somar;
                case TipoOperacao.Subtracao:
                    return Subtrair;
                //case TipoOperacao.Multiplicacao:
                //    return Multiplicar;
                default:
                    throw new Exception();
            }
        }
    }
}
