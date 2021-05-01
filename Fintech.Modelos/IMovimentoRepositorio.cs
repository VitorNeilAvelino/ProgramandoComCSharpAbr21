using System.Collections.Generic;

namespace Fintech.Modelos
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        void Atualizar(Movimento movimento);
        List<Movimento> Selecionar(Conta conta);
        void Excluir(int id);
    }
}