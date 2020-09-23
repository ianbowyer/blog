using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bowyer.Blog.Builders.Database;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactsDbContext _contactsDbContext;

        public ContactService(ContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext;
        }

        public IList<Contact> GetAll(string filter)
        {
            return _contactsDbContext.Contact
                .Where(w => w.FirstName.Contains(filter)
                    || w.MiddleNames.Contains(filter)
                    || w.LastName.Contains(filter)
                    || w.EmailAddress.Contains(filter))
                .ToList();
        }
    }

    public interface IContactService
    {
        IList<Contact> GetAll(string filter);
    }
}