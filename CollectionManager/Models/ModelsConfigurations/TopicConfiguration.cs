using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionManager.Models.ModelsConfigurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            ConfigureName(builder);
        }

        public void ConfigureName(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(topic => topic.Name).HasMaxLength(25);
            builder.Property(topic => topic.Name).IsRequired();
        }
    }
}
