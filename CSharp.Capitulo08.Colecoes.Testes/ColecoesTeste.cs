using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            List<int> inteiros = new List<int>(/*1000*/) { 2, 0, -96};
            inteiros.Add(44);
            inteiros.Add(4);
            inteiros.Add(-89);

            inteiros[0] = 5;
            //inteiros[10] = 28;

            var maisInteiros = new List<int> { 2, 0, 5, 2 };

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);
            inteiros.Remove(0);
            inteiros.RemoveAt(6);
            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros[inteiros.Count -1];
            ultimo = inteiros.Last();

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2021, 11, 15), "Proclamação da República");
            feriados.Add(Convert.ToDateTime("20/11/2021"), "Consciência Negra");
            feriados.Add(Convert.ToDateTime("25/01/2021"), "Aniversário de São Paulo");
            //feriados.Add(Convert.ToDateTime("25/01/2021"), "Aniversário de São Paulo");

            var proclamacao = feriados[new DateTime(2021, 11, 15)];

            foreach (var feriado in feriados)
            {
                Console.WriteLine($"{feriado.Key.ToShortDateString()}: {feriado.Value}");
            }

            Console.WriteLine(feriados.ContainsKey(Convert.ToDateTime("25/01/2021")));
            Console.WriteLine(feriados.ContainsValue("Proclamação da República"));
        }
    }
}
