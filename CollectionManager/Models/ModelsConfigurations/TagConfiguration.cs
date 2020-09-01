using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            ConfigureValue(builder);
            ConfigureTaggedItemId(builder);
        }

        public void ConfigureValue(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(tag => tag.Value).HasMaxLength(15);
            builder.Property(tag => tag.Value).IsRequired();
        }

        public void ConfigureTaggedItemId(EntityTypeBuilder<Tag> builder)
        {
            builder.HasOne(t => t.TaggedItem).WithMany(i => i.Tags).HasForeignKey(t => t.TaggedItemId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(tag => tag.TaggedItemId).IsRequired();
        }
    }
}
