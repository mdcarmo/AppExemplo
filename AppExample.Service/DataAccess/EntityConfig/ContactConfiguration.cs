using AppExample.Service.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AppExample.Service.DataAccess.EntityConfig
{
	public class ContactConfiguration : EntityTypeConfiguration<Contact>
	{
		public ContactConfiguration()
        {
            HasKey(x => x.ContactId);

            Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

            Property(x => x.Phone)
            .IsRequired()
            .HasMaxLength(10);

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            //Adicionado um Index
            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(160)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Idx_Contact_Email") { IsUnique = true }));

            ToTable("TB_CONTACT");
        }
	}
}
