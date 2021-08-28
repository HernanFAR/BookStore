using AuthorDomain.Validators.AuthorAggregateRoot;
using FluentValidation;
using SharedKernel.Domain.Abstracts.Audited.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorDomain.Core.AuthorAggregateRoot
{
    public class Author : CUAuditedAggregateRoot<Guid>
    {
        private Author() { }

        public Author(string name, string subname, DateTime? birthDate = null) :
            base(Guid.NewGuid())
        {
            Name = name;
            Subname = subname;
            BirthDate = birthDate;

            Create();
        }

        public string Name { get; private set; } = string.Empty;

        public string Subname { get; private set; } = string.Empty;

        public DateTime? BirthDate { get; private set; }

        private List<AcademicDegree> _Degrees = new();

        public IEnumerable<AcademicDegree> Degrees { get => _Degrees; }

        public Task UpdateInformation(string name, string subname, DateTime? birthDate)
        {
            Name = name;
            Subname = subname;
            BirthDate = birthDate;

            Update();

            return Task.CompletedTask;
        }

        public Task AddDegree(AcademicDegree academicDegree)
        {
            _Degrees.Add(academicDegree);

            Update();

            return Task.CompletedTask;
        }

        public Task RemoveDegree(Guid academicDegree)
        {
            _Degrees = _Degrees.Where(e => e.Id != academicDegree)
                .ToList();

            Update();

            return Task.CompletedTask;
        }

        public override Task ValidateAsync()
        {
            var validator = new AuthorValidator();

            return validator.ValidateAndThrowAsync(this);
        }
    }
}
