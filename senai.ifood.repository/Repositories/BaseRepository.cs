using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using senai.ifood.domain.Contracts;
using senai.ifood.repository.Context;

namespace senai.ifood.repository.Repositories
{
    //CLASSE ONDE FICARÁ OS METODOS UTILIZADOS PELOS CONTROLLERS
    //TODAS OS CONTROLLERS USARÃO ESSES MÉTODOS COMO BASE.
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IFoodContext _dbContext;

        public BaseRepository(IFoodContext ifoodcontext)
        {
            _dbContext = ifoodcontext;
        }
        public int Atualizar(T dados)
        {
            try
            {
                _dbContext.Set<T>().Update(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T BuscarPorId(int id, string[] includes = null)
        {
            try
            {
                //COMANDO UTILIZADO PARA ENCONTRAR A CHAVE PRIMARIA INDEPENDENTE DA ENTIDADE ENVIADA PARA BUSCA.
                //AFINAL NÃO SABEMOS COMO EH CHAMADO A CHAVE PRIMARIA EM CADA ENTIDADE
                var chavePrimaria = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                return _dbContext.Set<T>().FirstOrDefault(e => EF.Property<int>(e, chavePrimaria.Name) == id);
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Deletar(T dados)
        {
            try
            {
                _dbContext.Set<T>().Remove(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Inserir(T dados)
        {
            try
            {
                _dbContext.Set<T>().Add(dados);
                return _dbContext.SaveChanges();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> Listar(string[] includes = null)
        {
            try
            {
                //PRECISAMOS DA query PARA CRIAR A QUERY DE BUSCA DOS ITENS RELACIONADOS AO ITEM LISTADO, COMO PRODUTOS.
                var query = _dbContext.Set<T>().AsQueryable();
                if(includes == null) return query.ToList();
                foreach (var item in includes)
                {
                    query = query.Include(item);    
                }

                return query.ToList();
            }
            catch(System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}