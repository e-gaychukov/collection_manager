using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            ConfigureContent(builder);
            ConfigureItem(builder);
            ConfigureAuthorId(builder);
        }

        public void ConfigureContent(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(comment => comment.Content).IsRequired();
            builder.Property(comment => comment.Content).HasMaxLength(300);
        }

        public void ConfigureItem(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(comment => comment.ItemId).IsRequired();
            builder.HasOne(c => c.CommentedItem).WithMany(i => i.Comments).HasForeignKey(c => c.ItemId).OnDelete(DeleteBehavior.Cascade);
        }

        public void ConfigureAuthorId(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.AuthorId).IsRequired();
        }
    }
}
