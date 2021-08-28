using AuthorDomain.Core;
using AuthorDomain.Core.AuthorAggregateRoot;
using AuthorDomain.Validators.AuthorAggregateRoot;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AuthorUnitTest.Domain.Validators.AuthorAggregareRoot
{
    public class AuthorValidatorTest_Spanish
    {
        [Fact]
        public async Task Validate_Failure_Should_HaveOneInErrorCount_Detail_AuthorNull()
        {
            // Arrange
            var expCount = 1;

            var validator = new AuthorValidator();
            Author? author = null;


            // Act
#pragma warning disable CS8604 // Posible argumento de referencia nulo
            var validationResult = await validator.ValidateAsync(author);
#pragma warning restore CS8604 // Posible argumento de referencia nulo


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "Debes enviar un autor");


        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Validate_Failure_Should_HaveOneInErrorCount_Detail_InvalidName(string name)
        {
            // Arrange
            var expCount = 1;
            var subname = "Test";

            var author = new Author(name, subname);

            var validator = new AuthorValidator();


            // Act
            var validationResult = await validator.ValidateAsync(author);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "El nombre del autor no es valido");


        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Validate_Failure_Should_HaveOneInErrorCount_Detail_InvalidSubame(string subname)
        {
            // Arrange
            var expCount = 1;
            var name = "Test";

            var author = new Author(name, subname);

            var validator = new AuthorValidator();


            // Act
            var validationResult = await validator.ValidateAsync(author);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "El apellido del autor no es valido");


        }

        [Fact]
        public async Task Validate_Failure_Should_HaveErrors_Detail_InvalidDegree()
        {
            // Arrange
            var expCount = 0;
            var name = "Test";
            var subname = "Test";
            var academicDegreeName = string.Empty;
            var academicDegreeUniversity = "test";

            var author = new Author(name, subname);
            var degree = new AcademicDegree(academicDegreeName, academicDegreeUniversity);

            await author.AddDegree(degree);

            var validator = new AuthorValidator();


            // Act
            var validationResult = await validator.ValidateAsync(author);


            // Assert
            validationResult.Errors.Should().HaveCountGreaterThan(expCount);


        }

        [Fact]
        public async Task Validate_Failure_Should_HaveErrors_Detail_NullDegree()
        {
            // Arrange
            var expCount = 1;
            var name = "Test";
            var subname = "Test";

            var author = new Author(name, subname);
            AcademicDegree? degree = null;

#pragma warning disable CS8604 // Posible argumento de referencia nulo
            await author.AddDegree(degree);
#pragma warning restore CS8604 // Posible argumento de referencia nulo

            var validator = new AuthorValidator();


            // Act
            var validationResult = await validator.ValidateAsync(author);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount)
                .And.Contain(e => e.ErrorMessage == "Debes enviar grados universitarios validos");


        }

        [Fact]
        public async Task Validate_Failure_Should_HaveErrorCountInOne_Detail_ByNotValidBirthDate()
        {
            // Arrange
            var expCount = 1;
            var name = "Test";
            var subname = "Test";
            var birthDate = DateTime.Now;

            var author = new Author(name, subname, birthDate);

            var validator = new AuthorValidator();


            // Act
            var validationResult = await validator.ValidateAsync(author);


            // Assert
            validationResult.Errors.Should().HaveCount(expCount).And
                .Contain(e => e.ErrorMessage == "El autor enviado no cumple con el minimo de edad (18)");


        }
    }
}
