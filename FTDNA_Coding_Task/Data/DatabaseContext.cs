using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FTDNA_Coding_Task.Data
{
	public class DatabaseContext : DbContext
	{
		/// <summary>
		/// Gets or sets the samples.
		/// </summary>
		/// <value>
		/// The samples.
		/// </value>
		public DbSet<Sample> Samples { get; set; }

		/// <summary>
		/// Gets or sets the statuses.
		/// </summary>
		/// <value>
		/// The statuses.
		/// </value>
		public DbSet<SampleStatus> Statuses { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>
		/// The user.
		/// </value>
		public DbSet<User> User { get; set; }

		/// <summary>
		/// <para>
		/// Override this method to configure the database (and other options) to be used for this context.
		/// This method is called for each instance of the context that is created.
		/// </para>
		/// <para>
		/// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
		/// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
		/// the options have already been set, and skip some or all of the logic in
		/// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
		/// </para>
		/// </summary>
		/// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
		/// typically define extension methods on this object that allow you to configure the context.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=FTDNA.db");
		}

		/// <summary>
		/// Override this method to further configure the model that was discovered by convention from the entity types
		/// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
		/// and re-used for subsequent instances of your derived context.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
		/// define extension methods on this object that allow you to configure aspects of the model that are specific
		/// to a given database.</param>
		/// <remarks>
		/// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
		/// then this method will not be run.
		/// </remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ConfigureStatuses(modelBuilder.Entity<SampleStatus>());
			ConfigureUsers(modelBuilder.Entity<User>());
			ConfigureSamples(modelBuilder.Entity<Sample>());
		}

		/// <summary>
		/// Configures the users.
		/// </summary>
		/// <param name="entityTypeBuilder">The entity type builder.</param>
		private void ConfigureUsers(EntityTypeBuilder<User> entityTypeBuilder)
		{
			entityTypeBuilder.ToTable("Users");
			entityTypeBuilder.HasKey(v => v.UserId);

		}

		/// <summary>
		/// Configures the samples.
		/// </summary>
		/// <param name="entityTypeBuilder">The entity type builder.</param>
		private void ConfigureSamples(EntityTypeBuilder<Sample> entityTypeBuilder)
		{
			entityTypeBuilder.ToTable("Samples");
			entityTypeBuilder.HasKey(v => v.SampleId);

			entityTypeBuilder
				.HasOne(c => c.Status)
				.WithMany(c => c.Samples)
				.HasForeignKey(v=>v.StatusId);

			entityTypeBuilder
				.HasOne(c => c.CreatedBy)
				.WithMany(c => c.Samples)
				.HasForeignKey(c=>c.CreatedById);
		}

		/// <summary>
		/// Configures the statuses.
		/// </summary>
		/// <param name="entityTypeBuilder">The entity type builder.</param>
		private void ConfigureStatuses(EntityTypeBuilder<SampleStatus> entityTypeBuilder)
		{
			entityTypeBuilder.ToTable("Statuses");
			entityTypeBuilder.HasKey(v => v.StatusId);

		}
	}

}
