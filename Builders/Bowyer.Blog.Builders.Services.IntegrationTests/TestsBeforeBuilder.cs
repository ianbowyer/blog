using System.Linq;
using System.Runtime.InteropServices;
using Bowyer.Blog.Builders.Database.Entities;
using Bowyer.Blog.Builders.Services.IntegrationTests.Database;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework;

namespace Bowyer.Blog.Builders.Services.IntegrationTests
{
    public class Tests: TestWithSqlServer
    {
        private ContactService _service;

        [SetUp]
        public void Setup()
        {
            ClearDatabase();
            _service = new ContactService(DbContext);
        }

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