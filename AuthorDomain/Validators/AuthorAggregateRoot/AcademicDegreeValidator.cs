using AuthorDomain.Core;
using FluentValidation;
using FluentValidation.Results;
using Resources = AuthorDomain.Properties.Validators.AuthorAggregateRoot.AcademicDegreeValidator;

namespace AuthorDomain.Validators.AuthorAggregateRoot
{
    public class AcademicDegreeValidator : AbstractValidator<AcademicDegree>
    {
        public AcademicDegreeValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage(Resources.LanguageResources.NameNotEmpty);

            RuleFor(e => e.University)
                .NotEmpty().WithMessage(Resources.LanguageResources.UniversityNotEmpty);
        }

        protected override bool PreValidate(ValidationContext<AcademicDegree> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure(
                    typeof(AcademicDegree).Name,
                    Resources.LanguageResources.AcademicDegreeNull
                ));

                return false;
            }

            return true;
        }
    }
}
