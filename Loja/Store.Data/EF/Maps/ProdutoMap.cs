using Store.Domain.Enitities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.EF.Maps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            //tabela
            ToTable(nameof(Produto));

            //Chave primaria
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            Property(c => c.Preco).HasColumnType("money");

            Property(c => c.Quantidade);

            Property(c => c.TipoProdutoId);

            Property(c => c.DataCadastro);

            //relacionamento
            HasRequired(prod => prod.TipoProduto).WithMany(tipo => tipo.Podutos).HasForeignKey(fk => fk.TipoProdutoId);

        }
    }
}
