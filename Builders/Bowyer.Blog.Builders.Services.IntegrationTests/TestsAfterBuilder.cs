using System.Linq;
using Bowyer.Blog.Builders.Builders;
using Bowyer.Blog.Builders.Services.IntegrationTests.Database;
using NUnit.Framework;

namespace Bowyer.Blog.Builders.Services.IntegrationTests
{
    /// <summary>
    /// The tests to demonstrate tests using the Builder classes
    /// </summary>
    public class TestsAfterBuilder: TestWithSqlServer
    {
        /// <summary>
        /// The service under test.
        /// </summary>
        private ContactService _service;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            ClearDatabase();
            _service = new ContactService(DbContext);
        }

        /// <summary>
        /// Test demonstrating creating 3 contacts using a builder.
        /// </summary>
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

        /// <summary>
        /// Test demonstrating creating a contact with three different addresses.
        /// </summary>
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