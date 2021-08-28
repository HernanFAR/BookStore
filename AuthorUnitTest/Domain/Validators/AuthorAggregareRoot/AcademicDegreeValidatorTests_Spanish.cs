using AuthorDomain.Core;
using AuthorDomain.Validators.AuthorAggregateRoot;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace AuthorUnitTest.Domain.Validators.AuthorAggregareRoot
{
    public class AcademicDegreeValidatorTests_Spanish
    {

        [Fact]
        public async Task Validate_Failure_Should_HaveOneErrorCount_Detail_NullDegree()
        {
            // Arrange
            var expCount = 1;
            AcademicDegree? academicDegree = null;

            var validator = new AcademicDegreeValidator();

            // Act
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var validationResult = await validator.ValidateAsync(academicDegree);
#pragma warning restore CS8604 // Posible argumento de referencia nulo


            // Assert
            validationResult.Errors.Should().HaveCount(expCount)
                .And.Contain(e => e.ErrorMessage == "El grado academico es invalido");


        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Validate_Failure_Should_HaveOneErrorCount_Detail_NotValidName(string name)
        {
            // Arrange
            var university = "Nombre";
            var expCount = 1;

            var academicDegree = new AcademicDegree(name, university);

            var validator = new AcademicDegreeValidator();

            // Act
            var validationResult = await validator.ValidateAsync(academicDegree);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "El nombre ingresado en algun grado academico es invalido");


        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Validate_Failure_Should_HaveOneErrorCount_Detail_NotValidUniversity(string university)
        {
            // Arrange
            var name = "Nombre";
            var expCount = 1;

            var academicDegree = new AcademicDegree(name, university);

            var validator = new AcademicDegreeValidator();

            // Act
            var validationResult = await validator.ValidateAsync(academicDegree);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "El nombre ingresado en algun universidad es invalido");


        }

        [Fact]
        public async Task Validate_Success_Should_ValidationResultBeValid()
        {
            // Arrange
            var name = "Nombre";
            var university = "Nombre";
            var expCount = 0;

            var academicDegree = new AcademicDegree(name, university);

            var validator = new AcademicDegreeValidator();


            // Act
            var validationResult = await validator.ValidateAsync(academicDegree);


            // Assert
            validationResult.IsValid.Should().BeTrue();
            validationResult.Errors.Should().HaveCount(expCount);


        }
    }
}
