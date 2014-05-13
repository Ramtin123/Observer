using Endeavour.DomainClasses.Observer;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Endeavour.OBSERVER.DataLayerMappings.Observer
{
    public class TopicMap : EntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.TopicName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Topic");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TopicName).HasColumnName("TopicName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated").IsRequired();
            this.Property(t => t.Status).HasColumnName("Status").IsRequired();

            //this.HasOptional(t => t.Form)
                .WithRequired(t => t.Topic)
                .Map(x => x.MapKey("TopicId"))

                ;
        }
    }
}
