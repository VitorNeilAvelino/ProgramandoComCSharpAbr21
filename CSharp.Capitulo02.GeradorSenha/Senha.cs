using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        //public Senha()
        //{
        //    Valor = GerarSenha();
        //}

        public Senha(int tamanho = TamanhoMinimo)
        {
            tamanho = tamanho < TamanhoMinimo ? TamanhoMinimo : tamanho;
            tamanho = tamanho > TamanhoMaximo ? TamanhoMaximo : tamanho;

            Tamanho = tamanho;

            Valor = GerarSenha();
        }

        ~Senha()
        {
            Console.WriteLine("Hasta la vista, baby");
        }

        public const int TamanhoMinimo = 4;
        public const int TamanhoMaximo = 10;
        public int Tamanho { get; set; } //= TamanhoMinimo;
        public string Valor { get; set; }

        private string GerarSenha()
        {
            var senha = "";
            var randomico = new Random();

            for (int i = 0; i < Tamanho; i++)
            {
                senha += randomico.Next(10);
            }

            return senha;
        }
    }
}
