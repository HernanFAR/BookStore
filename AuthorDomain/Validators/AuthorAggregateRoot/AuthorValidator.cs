using AuthorDomain.Core.AuthorAggregateRoot;
using FluentValidation;
using FluentValidation.Results;
using System;
using Resources = AuthorDomain.Properties.Validators.AuthorAggregateRoot.AuthorValidator;

namespace AuthorDomain.Validators.AuthorAggregateRoot
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        private static readonly int _TotalDaysInYear = 365;
        private static readonly int _MinimumAge = 18;

        public AuthorValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage(Resources.LanguageResources.NameNotEmpty);

            RuleFor(e => e.Subname)
                .NotEmpty().WithMessage(Resources.LanguageResources.SubnameNotEmpty);

            RuleForEach(e => e.Degrees)
                .NotNull().WithMessage(Resources.LanguageResources.DegreeNotNull)
                .SetValidator(new AcademicDegreeValidator());

            When(e => e.BirthDate is not null, () =>
            {
                RuleFor(e => e.BirthDate!.Value)
                    .Must(BeAdult).WithMessage(string.Format(Resources.LanguageResources.BirthDateMustBeAdult, _MinimumAge));
            });
                
        }

        private bool BeAdult(DateTime birthDate)
        {
            var difference = birthDate - DateTime.Now;

            var years = difference.TotalDays / _TotalDaysInYear;

            return years > _MinimumAge;
        }

        protected override bool PreValidate(ValidationContext<Author> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure(
                    typeof(Author).Name,
                    Resources.LanguageResources.AuthorNull
                ));

                return false;
            }

            return true;
        }


    }
}
