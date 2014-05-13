using Endeavour.DomainClasses.Observer;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Endeavour.OBSERVER.DataLayerMappings.Observer
{
    public class ObservationMap : EntityTypeConfiguration<Observation>
    {
        public ObservationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Observation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TopicId).HasColumnName("TopicId").IsRequired();
            this.Property(t => t.DateCreated).HasColumnName("DateCreated").IsRequired();
            this.Property(t => t.Status).HasColumnName("Status").IsRequired();
            this.Property(t => t.CreatedById).HasColumnName("CreatedById").IsRequired();
            this.Property(t => t.OfficalDate).HasColumnName("OfficalDate").IsRequired();

            // Relationships
            this.HasRequired(t => t.Topic)
                .WithMany(t =>t.Observations)
                .HasForeignKey(d => d.TopicId);

           
        }
    }
}
