using Store.Domain.Enitities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.EF.Maps
{
    public class TipoProdutoMap : EntityTypeConfiguration<TipoProduto>
    {
        public TipoProdutoMap()
        {
            //tabela
            ToTable(nameof(TipoProduto));

            //chave primaria
            HasKey(pk => pk.Id);

            //colunas
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            Property(c => c.DataCadastro);

            //relacionamento
        }
    }
}
