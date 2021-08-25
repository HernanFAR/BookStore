using SharedKernel.Domain.Interfaces;
using SharedKernel.Domain.Interfaces.Abstracts;

namespace Microsoft.EntityFrameworkCore.Metadata.Builders
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureBaseClass(this EntityTypeBuilder b)
        {
            TryConfigureEntity(b);
            TryConfigureCreatedDate(b);
            TryConfigureUpdatedDate(b);
            TryConfigureDeletedDate(b);
        }

        public static void TryConfigureEntity(EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo(typeof(IEntity<>)))
            {
                b.HasKey(nameof(IEntity<object>.Id));
            }
        }

        public static void ConfigureEntity<T>(this EntityTypeBuilder<T> b)
            where T : class, IEntity<object>
        {
            b.HasKey(e => e.Id);
        }

        public static void TryConfigureCreatedDate(EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasCreatedDate)))
            {
                b.Property(nameof(IHasCreatedDate.CreatedDate))
                    .IsRequired(false);
            }

            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasCreatedDate<>)))
            {
                b.Property(nameof(IHasCreatedDate<object>.CreatedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasCreatedDate<object>.CreatedBy))
                    .IsRequired(false);
            }
        }

        public static void ConfigureCreatedDate<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasCreatedDate
        {
            b.Property(e => e.CreatedDate)
                .IsRequired(false);
        }

        public static void ConfigureCreatedDate<T, TUserKey>(this EntityTypeBuilder<T> b)
            where T : class, IHasCreatedDate<TUserKey>
        {
            b.Property(e => e.CreatedDate)
                .IsRequired(false);

            b.Property(e => e.CreatedBy)
                .IsRequired(false);
        }

        public static void TryConfigureUpdatedDate(EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasUpdatedDate)))
            {
                b.Property(nameof(IHasUpdatedDate.UpdatedDate))
                    .IsRequired(false);
            }

            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasUpdatedDate<>)))
            {
                b.Property(nameof(IHasUpdatedDate<object>.UpdatedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasUpdatedDate<object>.UpdatedBy))
                    .IsRequired(false);
            }
        }

        public static void ConfigureUpdatedDate<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasUpdatedDate
        {
            b.Property(e => e.UpdatedDate)
                .IsRequired(false);
        }

        public static void ConfigureUpdatedDate<T, TUserKey>(this EntityTypeBuilder<T> b)
            where T : class, IHasUpdatedDate<TUserKey>
        {
            b.Property(e => e.UpdatedDate)
                .IsRequired(false);

            b.Property(e => e.UpdatedBy)
                .IsRequired(false);
        }

        public static void TryConfigureDeletedDate(EntityTypeBuilder b)
        {
            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasDeletedDate)))
            {
                b.Property(nameof(IHasDeletedDate<object>.Deleted))
                    .IsRequired();

                b.Property(nameof(IHasDeletedDate.DeletedDate))
                    .IsRequired(false);
            }

            if (b.Metadata.ClrType.IsAssignableTo(typeof(IHasDeletedDate<>)))
            {
                b.Property(nameof(IHasDeletedDate<object>.Deleted))
                    .IsRequired();

                b.Property(nameof(IHasDeletedDate<object>.DeletedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasDeletedDate<object>.DeletedBy))
                    .IsRequired();
            }
        }

        public static void ConfigureDeletedDate<T>(this EntityTypeBuilder<T> b)
            where T : class, IHasDeletedDate
        {
            b.Property(e => e.Deleted)
                .IsRequired();

            b.Property(nameof(IHasDeletedDate.DeletedDate))
                .IsRequired(false);
        }

        public static void ConfigureDeletedDate<T, TUserKey>(this EntityTypeBuilder<T> b)
            where T : class, IHasDeletedDate<TUserKey>
        {
            b.Property(e => e.Deleted)
                .IsRequired();

            b.Property(e => e.DeletedDate)
                .IsRequired(false);

            b.Property(e => e.DeletedBy)
                .IsRequired();
        }
    }
}
