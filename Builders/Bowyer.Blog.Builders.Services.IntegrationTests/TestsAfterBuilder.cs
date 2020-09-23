using System.Linq;
using System.Runtime.InteropServices;
using Bowyer.Blog.Builders.Builders;
using Bowyer.Blog.Builders.Database.Entities;
using Bowyer.Blog.Builders.Services.IntegrationTests.Database;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

namespace Bowyer.Blog.Builders.Services.IntegrationTests
{
    public class TestsAfterBuilder: TestWithSqlServer
    {
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            ClearDatabase();
            _service = new ContactService(DbContext);
        }

        [Test]
        public void AfterBuildersTests()
        {
            // Arrange
            for (int i = 1; i <= 3; i++)
            {
                var builder = new ContactBuilder()
                    .WithFirstName($"FirstName{i}")
                    .WithMiddleNames($"MiddleName{i}")
                    .WithLastName($"LastName{i}")
                    .WithEmailAddress($"Email@Emailaddress{i}.com");
                DbContext.Add(builder.Build());
            }
            DbContext.SaveChanges();

            var filter = "Name2";

            // Act
            var actual = _service.GetAll(filter);

            // Assert
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("FirstName2", actual.First().FirstName);
        }

        [Test]
        public void AfterBuilderTestsWithAddress()
        {
            // Arrange

            DbContext.Add(new ContactBuilder()
                .WithAddress(new AddressBuilder().WithHouseNameOrNumber("41"))
                .WithAddress(new AddressBuilder().WithHouseNameOrNumber("42"))
                .WithAddress(new AddressBuilder().WithHouseNameOrNumber("42A"))
            .Build());

            DbContext.SaveChanges();
            var filter = ContactBuilder.DefaultFirstName;

            // Act
            var actual = _service.GetAll(filter);

            // Assert
            var streetNumbers = actual.SelectMany(s => s.Addresses).Select(s => s.HouseNameOrNumber).ToList();

            Assert.Contains("41", streetNumbers);
            Assert.Contains("42", streetNumbers);
            Assert.Contains("42A", streetNumbers);
        }
    }
}