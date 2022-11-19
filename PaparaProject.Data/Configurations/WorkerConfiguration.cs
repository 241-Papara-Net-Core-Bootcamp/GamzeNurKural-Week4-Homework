using PaparaProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaparaProject.Data.Configurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Mail).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.ToTable("Workers");
        }
    }
}
