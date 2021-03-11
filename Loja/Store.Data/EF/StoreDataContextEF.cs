using Store.Domain.Enitities;
using System.Data.Entity;

namespace Store.Data.EF
{
    public class StoreDataContextEF : DbContext
    {
        public StoreDataContextEF() : base("StoreCon")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Maps.ProdutoMap());
            modelBuilder.Configurations.Add(new Maps.TipoProdutoMap());
            modelBuilder.Configurations.Add(new Maps.UsuarioMap());
        }
    }
}
