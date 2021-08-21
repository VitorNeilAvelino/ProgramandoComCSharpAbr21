using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Modelos;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True");

        [TestMethod()]
        public void InserirTest()
        {
            var movimento = new Movimento(Operacao.Deposito, 200.5m);
            movimento.Conta = new ContaCorrente(new Agencia { Numero = 123 }, 456, "X");

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(123, 456);

            Assert.IsTrue(movimentos.Count > 0);
        }

        [TestMethod()]
        public void SelecionarAsyncTest()
        {
            var movimentos = repositorio.SelecionarAsync(123, 456).Result;
        }
    }
}