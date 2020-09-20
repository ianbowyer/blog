using System;
using Bowyer.Blog.Builders.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bowyer.Blog.Builders.Database
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<PhoneNumber> PhoneNumber { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }

        public DbSet<Address> Address { get; set; }
    }
}