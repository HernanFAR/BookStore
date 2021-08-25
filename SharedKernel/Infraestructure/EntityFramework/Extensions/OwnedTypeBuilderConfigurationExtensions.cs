using SharedKernel.Domain.Interfaces;
using SharedKernel.Domain.Interfaces.Abstracts;

namespace Microsoft.EntityFrameworkCore.Metadata.Builders
{
    public static class OwnedNavigationBuilderConfigurationExtensions
    {
        public static void ConfigureBaseClass(this OwnedNavigationBuilder b)
        {
            TryConfigureEntity(b);
            TryConfigureCreatedDate(b);
            TryConfigureUpdatedDate(b);
            TryConfigureDeletedDate(b);
        }

        public static void TryConfigureEntity(OwnedNavigationBuilder b)
        {
            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IEntity<>)))
            {
                b.HasKey(nameof(IEntity<object>.Id));
            }
        }

        public static void ConfigureEntity<TEntity, TDependentEntity>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot<object>
            where TDependentEntity : class, IEntity<object>
        {
            b.HasKey(e => e.Id);
        }

        public static void TryConfigureCreatedDate(OwnedNavigationBuilder b)
        {
            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasCreatedDate)))
            {
                b.Property(nameof(IHasCreatedDate.CreatedDate))
                    .IsRequired(false);
            }

            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasCreatedDate<>)))
            {
                b.Property(nameof(IHasCreatedDate<object>.CreatedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasCreatedDate<object>.CreatedBy))
                    .IsRequired(false);
            }
        }

        public static void ConfigureCreatedDate<TEntity, TDependentEntity>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasCreatedDate
        {
            b.Property(e => e.CreatedDate)
                .IsRequired(false);
        }

        public static void ConfigureCreatedDate<TEntity, TDependentEntity, TUserKey>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasCreatedDate<TUserKey>
        {
            b.Property(e => e.CreatedDate)
                .IsRequired(false);

            b.Property(e => e.CreatedBy)
                .IsRequired(false);
        }

        public static void TryConfigureUpdatedDate(OwnedNavigationBuilder b)
        {
            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasUpdatedDate)))
            {
                b.Property(nameof(IHasUpdatedDate.UpdatedDate))
                    .IsRequired(false);
            }

            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasUpdatedDate<>)))
            {
                b.Property(nameof(IHasUpdatedDate<object>.UpdatedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasUpdatedDate<object>.UpdatedBy))
                    .IsRequired(false);
            }
        }

        public static void ConfigureUpdatedDate<TEntity, TDependentEntity>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasUpdatedDate
        {
            b.Property(e => e.UpdatedDate)
                .IsRequired(false);
        }

        public static void ConfigureUpdatedDate<TEntity, TDependentEntity, TUserKey>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasUpdatedDate<TUserKey>
        {
            b.Property(e => e.UpdatedDate)
                .IsRequired(false);

            b.Property(e => e.UpdatedBy)
                .IsRequired(false);
        }

        public static void TryConfigureDeletedDate(OwnedNavigationBuilder b)
        {
            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasDeletedDate)))
            {
                b.Property(nameof(IHasDeletedDate<object>.Deleted))
                    .IsRequired();

                b.Property(nameof(IHasDeletedDate.DeletedDate))
                    .IsRequired(false);
            }

            if (b.OwnedEntityType.ClrType.IsAssignableTo(typeof(IHasDeletedDate<>)))
            {
                b.Property(nameof(IHasDeletedDate<object>.Deleted))
                    .IsRequired();

                b.Property(nameof(IHasDeletedDate<object>.DeletedDate))
                    .IsRequired(false);

                b.Property(nameof(IHasDeletedDate<object>.DeletedBy))
                    .IsRequired();
            }
        }

        public static void ConfigureDeletedDate<TEntity, TDependentEntity>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasDeletedDate
        {
            b.Property(e => e.Deleted)
                .IsRequired();

            b.Property(nameof(IHasDeletedDate.DeletedDate))
                .IsRequired(false);
        }

        public static void ConfigureDeletedDate<TEntity, TDependentEntity, TUserKey>(this OwnedNavigationBuilder<TEntity, TDependentEntity> b)
            where TEntity : class, IAggregateRoot
            where TDependentEntity : class, IHasDeletedDate<TUserKey>
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
