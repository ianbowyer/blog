using System.Collections.Generic;

namespace Bowyer.Blog.Builders.Database.Entities
{
    /// <summary>
    /// The Contact Entity.
    /// </summary>
    /// <seealso cref="Bowyer.Blog.Builders.Database.Entities.ContactBase" />
    public class Contact: ContactBase
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle names.
        /// </summary>
        public string MiddleNames { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        public IList<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        public IList<Address> Addresses { get; set; }
    }
}