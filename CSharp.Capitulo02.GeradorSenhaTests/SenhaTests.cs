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
        [TestMethod]
        public void GerarSenhaSemParametrosDeveRetornarSenhaPadrao()
        {
            var senha = new Senha();

            var valorSenha = senha.GerarSenha();

            Assert.IsTrue(valorSenha.Length == Senha.TamanhoMinimo);
            Assert.IsTrue(int.TryParse(valorSenha, out int _));

            Console.WriteLine(valorSenha);
        }
    }
}