﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = repositorio.Selecionar(1, 1)
                .OrderBy(m => m.Valor)
                .OrderByDescending(m => m.Data);

            var primeiro = movimentos.First();

            Console.WriteLine(primeiro.Data);
        }

        [TestMethod]
        public void CountTeste()
        {
            var depositosConta2 = repositorio.Selecionar(2, 2)
                .Count(m => m.Operacao == Operacao.Deposito);

            Assert.AreEqual(depositosConta2, 1);
        }

        [TestMethod]
        public void LikeTeste() // %%
        {
            var movimentos = repositorio.Selecionar(1, 1)
                .Where(m => m.Data.ToString().Contains("03/05/2021"));

            foreach (var movimento in movimentos)
            {
                Console.WriteLine(movimento.Data);
            }
        }

        [TestMethod]
        public void MinTeste()
        {
            var menorDeposito = repositorio.Selecionar(1, 1)
                .Where(m => m.Operacao == Operacao.Deposito)
                .Min(m => m.Valor);

            Assert.IsTrue(menorDeposito == 0.5m);
        }

        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(1, 1)
                .Skip(1)
                .Take(5)
                .ToList();

            Assert.IsTrue(movimentos.Count == 5);
        }

        [TestMethod]
        public void BetweenTeste()
        {
            var movimentos = repositorio.Selecionar(1, 1).
                Where(m => m.Valor is (>= 10 and <= 30));

            foreach (var movimento in movimentos)
            {
                Console.WriteLine(movimento.Valor);
            }
        }

        [TestMethod]
        public void GroupByTeste()
        {
            var agrupamento = repositorio.Selecionar(1, 1)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key,  Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total}");
            }
        }
    }
}