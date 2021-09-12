using AuthorDomain.Constants;
using AuthorDomain.Core.AuthorAggregateRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthorInfraestructure.EntityFrameworkCore.Relations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable(typeof(Author).Name, DatabaseConstants.Schema);

            builder.ConfigureBaseClass();

            builder.Property(e => e.CreatedDate).IsRequired();

            builder.OwnsMany(e => e.Degrees, degree =>
            {
                degree.ToTable(typeof(AcademicDegree).Name, DatabaseConstants.Schema);

                degree.ConfigureBaseClass();

                degree.Property(e => e.Name)
                    .HasMaxLength(AcademicDegreeConstants.NameMaxLength)
                    .IsRequired();

                degree.Property(e => e.University)
                    .HasMaxLength(AcademicDegreeConstants.UniversityMaxLength)
                    .IsRequired();
            });

            builder.Property(e => e.Name)
                .HasMaxLength(AuthorConstants.NameMaxLength)
                .IsRequired();

            builder.Property(e => e.Subname)
                .HasMaxLength(AuthorConstants.SubnameMaxLength)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .IsRequired(false);
        }
    }
}
