using System.Linq;
using Bowyer.Blog.Builders.Database.Entities;
using Bowyer.Blog.Builders.Services.IntegrationTests.Database;
using NUnit.Framework;

namespace Bowyer.Blog.Builders.Services.IntegrationTests
{
    /// <summary>
    /// Tests Before creating builders to Demonstrate the log way of doing testing.
    /// </summary>
    /// <seealso cref="Bowyer.Blog.Builders.Services.IntegrationTests.Database.TestWithSqlServer" />
    public class TestsBeforeBuilder : TestWithSqlServer
    {
        /// <summary>
        /// The service
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
        /// Before the builders tests.
        /// </summary>
        [Test]
        public void BeforeBuildersTests()
        {
            // Arrange

            var contact1 = new Contact()
            {
                FirstName = "FirstName1",
                MiddleNames = "MiddleName1",
                LastName = "LastName1",
                EmailAddress = "Email@Emailaddress1.com",
            };
            var contact2 = new Contact()
            {
                FirstName = "FirstName2",
                MiddleNames = "MiddleName2",
                LastName = "LastName2",
                EmailAddress = "Email@Emailaddress2.com",
            };
            var contact3 = new Contact()
            {
                FirstName = "FirstName3",
                MiddleNames = "MiddleName3",
                LastName = "LastName3",
                EmailAddress = "Email@Emailaddress3.com",
            };
            var filter = "Name2";
            DbContext.AddRange(contact1,contact2,contact3);
            DbContext.SaveChanges();

            // Act
            var actual = _service.GetAll(filter);

            // Assert
            Assert.AreEqual("FirstName2", actual.First().FirstName);
        }
    }
}