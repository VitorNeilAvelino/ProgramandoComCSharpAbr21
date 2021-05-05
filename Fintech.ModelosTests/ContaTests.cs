using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Modelos.Tests
{
    [TestClass()]
    public class ContaTests
    {
        [TestMethod()]
        public void EfetuarOperacaoTest()
        {
            var conta = new ContaEspecial/*()*/ { Limite = 1000 };
            //conta.Limite = 1000;
            //conta.Saldo = 50;

            conta.EfetuarOperacao(50m, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 50m);

            conta.EfetuarOperacao(20m, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == 30m);

            conta.EfetuarOperacao(40m, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -10m);

            conta.EfetuarOperacao(990m, Operacao.Saque);
            Assert.IsTrue(conta.Saldo == -1000m);

            Assert.ThrowsException<SaldoInsuficienteException>(() => conta.EfetuarOperacao(10m, Operacao.Saque));

            try
            {
                conta.EfetuarOperacao(10m, Operacao.Saque);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(conta.Saldo == -1000m);                
                Assert.IsInstanceOfType(ex, typeof(SaldoInsuficienteException));
            }

            conta.EfetuarOperacao(1000m, Operacao.Deposito);
            Assert.IsTrue(conta.Saldo == 0m);

            Assert.AreEqual(conta.Movimentos.Count, 5);

            foreach (var movimento in conta.Movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor:c}");
            }

            var depositos = conta.Movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(m => m.Valor);

            var saques = conta.Movimentos
                .Where(m => m.Operacao == Operacao.Saque)
                .Sum(m => m.Valor);

            Assert.AreEqual(conta.Saldo, depositos - saques);
        }
    }
}