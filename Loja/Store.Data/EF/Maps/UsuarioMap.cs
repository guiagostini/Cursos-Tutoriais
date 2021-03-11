using Store.Domain.Enitities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Store.Data.EF.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //tabela
            ToTable(nameof(Usuario));

            //Chave primaria
            HasKey(pk => pk.Id);

            //Colunas
            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption
                .Identity);

            Property(c => c.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(80)
                .IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_dbo_Usuario.Email") { IsUnique = true })
                    );

            Property(c => c.Senha).
                HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.DataCadastro);

            //relacionamento
        }
    }
}
