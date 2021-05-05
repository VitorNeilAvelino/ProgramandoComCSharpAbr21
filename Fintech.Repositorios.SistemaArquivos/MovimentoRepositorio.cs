using Fintech.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

        private const string DiretorioBase = "Dados";
        public string Caminho { get; /*private set;*/ }

        public void Atualizar(Movimento movimento)
        {
            
        }

        public void Excluir(int id)
        {
            
        }

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Conta.Agencia.Numero};{movimento.Conta.Numero};" +
                $"{movimento.Data};{(int)movimento.Operacao};{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText($"{DiretorioBase}\\Movimento.txt", registro + Environment.NewLine);
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            //Thread.Sleep(7000);

            var movimentos = new List<Movimento>();

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                if (linha.Trim() == string.Empty) continue;

                var propriedades = linha.Split(';');
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[0]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[1]);
                var data = Convert.ToDateTime(propriedades[2]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[3]);
                var valor = Convert.ToDecimal(propriedades[4]);

                if (numeroAgencia == propriedadeNumeroAgencia && 
                    numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(operacao, valor);
                    movimento.Data = data;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public List<Movimento> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            //Thread.Sleep(7000);

            var movimentos = new List<Movimento>();

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                if (linha.Trim() == string.Empty) continue;

                var propriedades = linha.Split(';');
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[0]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[1]);
                var data = Convert.ToDateTime(propriedades[2]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[3]);
                var valor = Convert.ToDecimal(propriedades[4]);

                if (numeroAgencia == propriedadeNumeroAgencia &&
                    numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(operacao, valor);
                    movimento.Data = data;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }
    }
}