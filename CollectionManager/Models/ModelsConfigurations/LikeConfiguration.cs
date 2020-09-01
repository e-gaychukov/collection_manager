using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            ConfigureItemId(builder);
            ConfigureSupporterId(builder);
        }

        public void ConfigureItemId(EntityTypeBuilder<Like> builder)
        {
            builder.Property(like => like.ItemId).IsRequired();
            builder.HasOne(lk => lk.LikedItem).WithMany(i => i.Likes).HasForeignKey(lk => lk.ItemId).OnDelete(DeleteBehavior.Cascade);
        }

        public void ConfigureSupporterId(EntityTypeBuilder<Like> builder)
        {
            builder.Property(lk => lk.SupporterId).IsRequired();
        }
    }
}
