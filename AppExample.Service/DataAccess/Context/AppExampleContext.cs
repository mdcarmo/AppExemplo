using AppExample.Service.DataAccess.EntityConfig;
using AppExample.Service.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace AppExample.Service.DataAccess.Context
{
	public class AppExampleContext : DbContext
	{
		public AppExampleContext()
		{
				
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties()
			  .Where(p => p.Name == p.ReflectedType.Name + "Id")
			  .Configure(p => p.IsKey());

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(100));

			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new ContactConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			//cria o campo de data registro automaticamente
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null))
			{
				if (entry.State == EntityState.Added)
					entry.Property("DateRegister").CurrentValue = DateTime.Now;

				if (entry.State == EntityState.Modified)
					entry.Property("DateRegister").IsModified = false;
			}

			return base.SaveChanges();
		}
	}
}