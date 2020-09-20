using System;
using Bowyer.Blog.Builders.Database;

namespace Bowyer.Blog.Builders.Services
{
    public class ContactService
    {
        private readonly ContactsDbContext _contactsDbContext;

        public ContactService(ContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext;
        }
    }
}