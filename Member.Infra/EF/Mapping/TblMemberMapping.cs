using Member.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Member.Infrastructure.Data.Mappings
{
    public class MemberMapping : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.ToTable("members");

            builder.HasKey(m => m.codMember);

            builder.Property(m => m.codMember)
                   .HasColumnName("cod_member")
                   .IsRequired();

            builder.Property(m => m.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(m => m.BirthDate)
                   .HasColumnName("birth_date")
                   .IsRequired();

            builder.Property(m => m.Cargo)
                   .HasColumnName("cargo")
                   .HasConversion<int>(); // Enum como int
        }
    }
}
