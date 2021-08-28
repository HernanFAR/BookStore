using SharedKernel.Domain.Abstracts.Audited.Entities;
using System;

namespace AuthorDomain.Core.AuthorAggregateRoot
{
    public class AcademicDegree : CAuditedEntity<Guid>
    {
        private AcademicDegree() { }

        public AcademicDegree(string name, string university) :
            base(Guid.NewGuid())
        {
            Name = name;
            University = university;

            Create();
        }

        public string Name { get; private set; } = string.Empty;
        public string University { get; private set; } = string.Empty;
    }
}
