using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Modelos
{
    public interface ICrudRepositorio<T>
    {
        void Inserir(T cliente);
        void Atualizar(T cliente);
        List<T> Selecionar();
        Cliente Selecionar(int id);
        Task<List<T>> SelecionarAsync();
        void Excluir(int id);
    }
}
