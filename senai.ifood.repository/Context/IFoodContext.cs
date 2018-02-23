using Microsoft.EntityFrameworkCore;
using senai.ifood.domain.Entities;

namespace senai.ifood.repository.Context
{
    //BAIXAR PACOTE DO NUGET PARA UTILIZAR O DBCONTEXT (Microsoft.EntityFrameworkCore / Microsoft.EntityFrameworkCore.SqlServer / Microsoft.EntityFrameworkCore.Relational)
    //ADICIONAR REFERENCIAS (novo itemgroup) NO .csproj DO PROJETO
    public class IFoodContext : DbContext
    {
        //CONSTRUTOR PARA UTILIZAR AS FUNCOES DE CONSTRUCAO DO BANCO DE DADOS
        public IFoodContext(DbContextOptions<IFoodContext> options): base(options)
        {

        }      
        
        //PROPRIEDADES PARA CRIACAO NO BANCO DE DADOS DAS TABELAS E RELACIONAMENTOS
        public DbSet<UsuarioDomain> Usuarios { get; set; }
        public DbSet<ClienteDomain> Clientes { get; set; }
        public DbSet<EspecialidadeDomain> Especialidades { get; set; }
        public DbSet<PermissaoDomain> Permissoes { get; set; }
        public DbSet<ProdutoDomain> Produtos { get; set; }
        public DbSet<RestauranteDomain> Restaurantes { get; set; }
        public DbSet<UsuarioPermissaoDomain> UsuariosPermissoes { get; set; }
        
        //CONFIGURA COMO SERA A CRIACAO DAS TABELAS COM SEUS NOMES NO BANCO DE DADOS'
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ClienteDomain>().ToTable("Clientes");
            modelBuilder.Entity<UsuarioDomain>().ToTable("Usuarios");
            modelBuilder.Entity<EspecialidadeDomain>().ToTable("Especialidades");
            modelBuilder.Entity<PermissaoDomain>().ToTable("Permissoes");
            modelBuilder.Entity<ProdutoDomain>().ToTable("Produtos");
            modelBuilder.Entity<RestauranteDomain>().ToTable("Restaurantes");
            modelBuilder.Entity<UsuarioPermissaoDomain>().ToTable("UsuariosPermissoes");

            base.OnModelCreating(modelBuilder);   
        }
        
        
        
        
        
        
        
    }
}