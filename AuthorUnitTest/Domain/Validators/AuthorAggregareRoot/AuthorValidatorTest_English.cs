using AuthorDomain.Core;
using AuthorDomain.Core.AuthorAggregateRoot;
using AuthorDomain.Validators.AuthorAggregateRoot;
using FluentAssertions;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AuthorUnitTest.Domain.Validators.AuthorAggregareRoot
{
    public class AuthorValidatorTest_English
    {
        public AuthorValidatorTest_English()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
        }

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
                .Contain(e => e.ErrorMessage == "You must send a author");


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
                .Contain(e => e.ErrorMessage == "The name of the author is not valid");


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
                .Contain(e => e.ErrorMessage == "The subname of the author is not valid");


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
                .And.Contain(e => e.ErrorMessage == "You must send valid academic grades");


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
                .Contain(e => e.ErrorMessage == "The sended author doesn't have the legal age (18)");


        }
    }
}
