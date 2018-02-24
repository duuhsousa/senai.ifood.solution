using System.Collections.Generic;

namespace senai.ifood.domain.Contracts
{
    //TODAS AS CLASSES DO REPOSITORIO IRAO SEGUIR ESSA INTERFACE, IGUAL UM CONTRATO.
    public interface IBaseRepository<T> where T : class
    {
        //ADICIONAMOS O INCLUDE PARA NA RESPOSTA O BANCO ENVIAR OS DADOS DAS TABELAS RELACIONADAS
        IEnumerable<T> Listar(string[] includes = null);
        int Atualizar(T dados);
        int Inserir(T dados);
        int Deletar(T dados);

        //ADICIONAMOS O INCLUDE PARA NA RESPOSTA O BANCO ENVIAR OS DADOS DAS TABELAS RELACIONADAS
        T BuscarPorId(int id, string[] includes = null);
    }
}