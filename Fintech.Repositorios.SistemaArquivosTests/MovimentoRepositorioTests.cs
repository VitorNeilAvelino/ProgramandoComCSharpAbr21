using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Modelos;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new ("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia { Numero = 1 };
            var conta = new ContaCorrente(agencia, 1, "1");

            var movimento = new Movimento(Operacao.Deposito, 50);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(1, 1);

            var totalDepositos = movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(m => m.Valor);

            var totalSaques = movimentos
                .Where(m => m.Operacao == Operacao.Saque)
                .Sum(m => m.Valor);

            var contaCorrente = new ContaCorrente();
            contaCorrente.Movimentos.AddRange(movimentos);

            Assert.AreEqual(contaCorrente.Saldo, totalDepositos - totalSaques);
        }
    }
}