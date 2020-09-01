using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            ConfigureName(builder);
            ConfigureDescription(builder);
            ConfigureTopicId(builder);
            ConfigureCustomFieldsNames(builder);
            ConfigureOwner(builder);
        }

        public void ConfigureName(EntityTypeBuilder<Collection> builder)
        {
            builder.Property(collection => collection.Name).IsRequired();
            builder.Property(collection => collection.Name).HasMaxLength(30);
        }

        public void ConfigureDescription(EntityTypeBuilder<Collection> builder)
        {
            builder.Property(collection => collection.Description).IsRequired();
            builder.Property(collection => collection.Description).HasMaxLength(50);
        }

        public void ConfigureTopicId(EntityTypeBuilder<Collection> builder)
        {
            builder.HasOne(c => c.Topic).WithMany(t => t.Collections).HasForeignKey(c => c.TopicId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(collection => collection.TopicId).IsRequired();
        }

        public void ConfigureCustomFieldsNames(EntityTypeBuilder<Collection> builder)
        {
            builder.OwnsOne(collection => collection.CustomFieldsNames);
        }

        public void ConfigureOwner(EntityTypeBuilder<Collection> builder)
        {
            builder.HasOne(c => c.Owner).WithMany().HasForeignKey(c => c.OwnerId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(collection => collection.OwnerId).IsRequired();
        }
    }
}
