using System;
using Bowyer.Blog.Builders.Database;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.Builders.Services.IntegrationTests.Database
{
    /// <summary>
    /// The Test with Sql Lite Base class used for testing against a in-memory database.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public abstract class TestWithSqlServer :IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Gets the Contacts database context.
        /// </summary>
        protected ContactsDbContext DbContext { get; }

        private const string InMemoryConnectionString = "Server=localhost;Database=TestContactsDatabase;Trusted_Connection=True;";
        protected DbContextOptions<ContactsDbContext> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestWithSqlServer"/> class.
        /// </summary>
        protected TestWithSqlServer()
        {
            _options = new DbContextOptionsBuilder<ContactsDbContext>()
                .UseSqlServer(InMemoryConnectionString)
                .Options;
            DbContext = new ContactsDbContext(_options);
            DbContext.Database.EnsureCreated();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected void ClearDatabase()
        {
            DbContext.Address.RemoveRange(DbContext.Address);
            DbContext.Contact.RemoveRange(DbContext.Contact);
            DbContext.PhoneNumber.RemoveRange(DbContext.PhoneNumber);

            DbContext.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // free managed resources
                DbContext.Dispose();
            }

            _isDisposed = true;
        }
    }
}