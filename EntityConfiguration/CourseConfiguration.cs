using BDolma_SMS.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BDolma_SMS.EntityConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

            builder.Property(e => e.CourseName)
                .HasMaxLength(200)
                .IsUnicode(true);

            builder.Property(e => e.CourseDescription)
                .HasMaxLength(500)
                .IsUnicode(true);

            builder.HasMany(e => e.Students)
                .WithOne(pt => pt.Course)
                .HasForeignKey(e => e.CourseId);

            builder.Property(e => e.IsActive)
           .HasDefaultValue(true);

            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .IsUnicode(true);
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime");

            builder.Property(e => e.ModifiedBy)
                .IsUnicode(true);


        }
    }
}
