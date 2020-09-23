using Bowyer.Blog.Builders.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.Builders.Database
{
    /// <summary>
    /// The Contact DB Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class ContactsDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public DbSet<Contact> Contact { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public DbSet<PhoneNumber> PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the phone number.
        /// </summary>
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public DbSet<Address> Address { get; set; }
    }
}