using System.Collections.Generic;
using System.Linq;
using Bowyer.Blog.Builders.Database;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Services
{
    /// <summary>
    /// The Contact Service
    /// </summary>
    public class ContactService : IContactService
    {
        /// <summary>
        /// The contacts database context
        /// </summary>
        private readonly ContactsDbContext _contactsDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="contactsDbContext">The contacts database context.</param>
        public ContactService(ContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>A List of <see cref="Contact"/></returns>
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
}