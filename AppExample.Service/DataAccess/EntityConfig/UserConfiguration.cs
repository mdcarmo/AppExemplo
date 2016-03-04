using AppExample.Service.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AppExample.Service.DataAccess.EntityConfig
{
	public class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
        {
            //chave primária
            HasKey(x => x.UserId);

            Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

            Property(u => u.Password)
                .HasMaxLength(500)
                .IsRequired();

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            //Adicionado um Index
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(160)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Idx_User_Email") { IsUnique = true }));

            //Mapeado para tabela USUARIO
            ToTable("TB_USER");
        }
	}
}
