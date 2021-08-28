using AuthorDomain.Core;
using AuthorDomain.Validators.AuthorAggregateRoot;
using FluentAssertions;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AuthorUnitTest.Domain.Validators.AuthorAggregareRoot
{
    public class AcademicDegreeValidatorTests_English
    {
        public AcademicDegreeValidatorTests_English()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
        }

        [Fact]
        public async Task Validate_Failure_Should_HaveOneErrorCount_Detail_NullDegree()
        {
            // Arrange
            var expCount = 1;
            AcademicDegree? academicDegree = null;

            var validator = new AcademicDegreeValidator();

            // Act
            var validationResult = await validator.ValidateAsync(academicDegree);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "The academic agrade is not valid");


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
                .Contain(e => e.ErrorMessage == "The sended name of some academic degree is not valid");


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
                .Contain(e => e.ErrorMessage == "The sended name of some university is not valid");


        }
    }
}
