using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            int[] inteiros = new int[5];
            inteiros[0] = 27;
            inteiros[1] = 7;
            inteiros[2] = 2;
            inteiros[3] = -8;
            inteiros[4] = 0;
            //inteiros[5] = 9;

            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };

            string[] nomes = { "João", "Edimilson" };

            //nomes[-1] = "Teste";

            var chars = new[] {'a', 'b', 'c' };

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}.");
        }

        [TestMethod]
        public void RedimensionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };
            
            Array.Resize(ref decimais, 5);
            
            decimais[4] = 6.8m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 1.4m, 0.9m, -4, 7.8m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -4);
        }

        private decimal Media(decimal valor1, decimal valor2) => (valor1 + valor2) / 2;
        //{
        //    return (valor1 + valor2) / 2;
        //}

        //TODO: Polimorfismo de sobrecarga.
        private decimal Media(params decimal[] valores)
        {
            var soma = 0m;

            foreach (var valor in valores)
            {
                soma += valor;
            }

            return soma / valores.Length;
        }

        [TestMethod]
        public void ParamsTeste()
        {
            decimal[] decimais = { 1.8m, 2, 4.8m};

            Console.WriteLine(Media(decimais));
            Console.WriteLine(Media(2, 0.8m, 1.2m, -8.9m));
            Console.WriteLine(decimais.Average());
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "João";

            Assert.AreEqual(nome[0], 'J');

            foreach (var letra in nome)
            {
                Console.Write(letra);
            }

            //StringBuilder
        }
    }
}
