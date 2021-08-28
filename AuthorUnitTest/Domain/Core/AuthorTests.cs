using AuthorDomain.Core;
using AuthorDomain.Core.AuthorAggregateRoot;
using FluentAssertions;
using FluentValidation;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AuthorUnitTest.Domain.Core
{
    public class AuthorTests
    {
        [Fact]
        public async Task UpdateInformation_Success_Should_UpdateAuthorInformation()
        {
            // Arrange
            var oldName = "test";
            var oldSubname = "test";
            DateTime? oldBirthDate = null;
            var expName = "test1";
            var expSubname = "test1";
            var expBirthDate = DateTime.Now;

            var author = new Author(oldName, oldSubname, oldBirthDate);

            // Act
            await author.UpdateInformation(expName, expSubname, expBirthDate);


            // Assert
            author.Name.Should().Be(expName);
            author.Subname.Should().Be(expSubname);
            author.BirthDate.Should().Be(expBirthDate);


        }

        [Fact]
        public async Task AddDegree_Success_Should_AddNewDegree()
        {
            // Arrange
            var oldName = "test";
            var oldSubname = "test";
            DateTime? oldBirthDate = null;

            var expCount = 1;
            var expName = "test1";
            var expUniversity = "test1";

            var author = new Author(oldName, oldSubname, oldBirthDate);
            var academicDegree = new AcademicDegree(expName, expUniversity);

            // Act
            await author.AddDegree(academicDegree);


            // Assert
            author.Degrees.Should().HaveCount(expCount);
            author.Degrees.Should().Contain(e => e.Name == expName && e.University == expUniversity);


        }

        [Fact]
        public async Task RemoveDegree_Success_Should_RemoveDegree()
        {
            // Arrange
            var oldName = "test";
            var oldSubname = "test";
            DateTime? oldBirthDate = null;

            var expCount = 0;
            var expName = "test1";
            var expUniversity = "test1";

            var author = new Author(oldName, oldSubname, oldBirthDate);
            var academicDegree = new AcademicDegree(expName, expUniversity);
            await author.AddDegree(academicDegree);

            // Act
            await author.RemoveDegree(academicDegree.Id);

            // Assert
            author.Degrees.Should().HaveCount(expCount);


        }

        [Fact]
        public async Task ValidateAsync_Failure_Should_ThrowValidationException()
        {
            // Arrange
            var oldName = "test";
            var oldSubname = "test";
            DateTime? oldBirthDate = DateTime.Now;

            var author = new Author(oldName, oldSubname, oldBirthDate);

            // Act
            Func<Task> act = () => author.ValidateAsync();

            // Assert
            await act.Should().ThrowExactlyAsync<ValidationException>();


        }
    }
}
