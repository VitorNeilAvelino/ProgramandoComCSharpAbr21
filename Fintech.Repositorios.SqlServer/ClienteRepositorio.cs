using Fintech.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Repositorios.SqlServer
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Selecionar()
        {
            throw new NotImplementedException();
        }

        public Cliente Selecionar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> SelecionarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
