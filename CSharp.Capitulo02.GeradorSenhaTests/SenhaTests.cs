using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        //[TestMethod]
        //public void GerarSenhaSemParametrosDeveRetornarSenhaPadrao()
        //{
        //    var senha = new Senha();

        //    var valorSenha = senha.GerarSenha();

        //    Assert.IsTrue(valorSenha.Length == Senha.TamanhoMinimo);
        //    Assert.IsTrue(int.TryParse(valorSenha, out int _));

        //    Console.WriteLine(valorSenha);
        //}

        [TestMethod]
        public void ConstrutorPadraoDeveRetornarSenhaPadrao()
        {
            var senha = new Senha();

            Assert.IsTrue(senha.Valor.Length == Senha.TamanhoMinimo);
            Assert.IsTrue(int.TryParse(senha.Valor, out int _));

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        [DataRow(8)]
        [DataRow(3)]
        [DataRow(11)]
        public void ConstrutorParametrizadoDeveRetornarSenhaEspecifica(int tamanho)
        {
            Senha senha = new(tamanho);

            //var nome = "vitor".Length;

            Assert.IsTrue(senha.Valor.Length == senha.Tamanho);
            Assert.IsTrue(long.TryParse(senha.Valor, out long _));

            Assert.IsTrue(senha.Tamanho >= Senha.TamanhoMinimo);
            Assert.IsTrue(senha.Tamanho <= Senha.TamanhoMaximo);

            Console.WriteLine(senha.Valor);
        }
    }
}