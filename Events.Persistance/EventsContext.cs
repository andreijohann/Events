using Events.Core;
using Events.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Persistence
{
    public class EventsContext : DbContext
    {

        public EventsContext()
            : base("name=EventsContext")
        {

        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Source> Sources { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Start Category Configurations

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                    new IndexAttribute() { IsUnique = true }));

            modelBuilder.Entity<Category>()
                .Property(c => c.Alias)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                    new IndexAttribute() { IsUnique = true }));

            modelBuilder.Entity<Category>()
                .Property(c => c.DthCreated)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // End Category Configurations

            // Start Tag Configurations

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                    new IndexAttribute() { IsUnique = true }));

            // End Tag Configurations

            // Start Source Configurations

            modelBuilder.Entity<Source>()
                .Property(s => s.SourceName)
                .IsRequired()
                .HasMaxLength(300);
                
            modelBuilder.Entity<Source>()
                .Property(s => s.SourceRegistry)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                    new IndexAttribute("IX_SOURCETYPE_REGISTRY", 1) { IsUnique = true }));

            modelBuilder.Entity<Source>()
                .Property(s => s.SourceType)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                    new IndexAttribute("IX_SOURCETYPE_REGISTRY", 2) { IsUnique = true }));

            modelBuilder.Entity<Source>()
                .Property(s => s.DthCreated)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // End Source Configurations

            // Start Event Configurations

            modelBuilder.Entity<Event>()
                .Property(e => e.ShortDescription)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Event>()
                .Property(e => e.DetailedDescription)
                .HasMaxLength(1000);

            modelBuilder.Entity<Event>()
                .Property(e => e.DthEvent)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Event>()
                .Property(e => e.DthCreated)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<Event>()
                 .HasRequired(e => e.Source)
                 .WithMany(s => s.Events)
                 .HasForeignKey(e => e.SourceId);

            modelBuilder.Entity<Event>()
                .HasRequired(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Tags)
                .WithMany()
                .Map(m => 
                    {
                        m.ToTable("EventTags");
                        m.MapLeftKey("EventId");
                        m.MapRightKey("TagId");
                    });

            // End Event Configurations

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
