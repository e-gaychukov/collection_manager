using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            ConfigureName(builder);
            ConfigureCustomFieldsValues(builder);
            ConfigureCollectionId(builder);
        }

        public void ConfigureName(EntityTypeBuilder<Item> builder)
        {
            builder.Property(item => item.Name).HasMaxLength(35);
            builder.Property(item => item.Name).IsRequired();
        }

        public void ConfigureCustomFieldsValues(EntityTypeBuilder<Item> builder)
        {
            builder.OwnsOne(item => item.CustomFieldsValues);
        }

        public void ConfigureCollectionId(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne(i => i.Collection).WithMany(c => c.Items).HasForeignKey(i => i.CollectionId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(item => item.CollectionId).IsRequired();
        }

        public void ConfigureAddingTime(EntityTypeBuilder<Item> builder)
        {
            builder.Property(item => item.AddingTime).HasDefaultValueSql("GETDATE()");
        }
    }
}
