using Dapper;
using Fintech.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Fintech.Repositorios.SqlServer
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        public MovimentoRepositorio(string stringConexao)
        {
            StringConexao = stringConexao;
        }

        public string StringConexao { get; private set; }

        public void Atualizar(Movimento movimento)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Movimento movimento)
        {
            var instrucao = @$"Insert Movimento(IdConta, Data, Valor, Operacao)
                                         values({movimento.Conta.Numero}, @Data, @Valor, @Operacao)";

            using (var conexao = new SqlConnection(StringConexao))
            {
                //GC.Collect();
                conexao.Execute(instrucao, movimento);
            }
        }

        public async Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            var instrucao = @"Select Data, Operacao, Valor 
                                        from Movimento 
                                        where IdConta = @numeroConta";

            using (var conexao = new SqlConnection(StringConexao))
            {
                var movimentos = await conexao.QueryAsync<Movimento>(instrucao, new { numeroConta });
                return movimentos.ToList();
            }
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            var instrucao = @"Select Data, Operacao, Valor 
                                        from Movimento 
                                        where IdConta = @numeroConta";

            using (var conexao = new SqlConnection(StringConexao))
            {
                return conexao.Query<Movimento>(instrucao, new { numeroConta }).AsList();
            }
        }
    }
}
