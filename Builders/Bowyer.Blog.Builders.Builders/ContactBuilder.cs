using System.Collections.Generic;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    /// <summary>
    /// The Contact Builder
    /// </summary>
    public class ContactBuilder : BuilderBase<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactBuilder"/> class.
        /// </summary>
        public ContactBuilder()
        {
            BuilderEntity.FirstName = DefaultFirstName;
            BuilderEntity.MiddleNames = DefaultMiddleNames;
            BuilderEntity.LastName = DefaultLastName;
            BuilderEntity.Company = DefaultCompany;
            BuilderEntity.EmailAddress = DefaultEmailAddress;
            BuilderEntity.PhoneNumbers = DefaultPhoneNumbers;
            BuilderEntity.Addresses = DefaultAddresses;
        }

        /// <summary>
        /// Gets the default name of the first.
        /// </summary>
        public static string DefaultFirstName { get; } = "Bob";

        /// <summary>
        /// Gets the default middle names.
        /// </summary>
        public static string DefaultMiddleNames { get; } = null;

        /// <summary>
        /// Gets the default name of the last.
        /// </summary>
        public static string DefaultLastName { get; } = "Jones";

        /// <summary>
        /// Gets the default company.
        /// </summary>
        public static string DefaultCompany { get; } = null;

        /// <summary>
        /// Gets the default email address.
        /// </summary>
        public static string DefaultEmailAddress { get; } = "bob.jones@email.com";

        /// <summary>
        /// Gets the default phone numbers.
        /// </summary>
        public static IList<PhoneNumber> DefaultPhoneNumbers { get;  } = new List<PhoneNumber>();

        /// <summary>
        /// Gets the default addresses.
        /// </summary>
        public static IList<Address> DefaultAddresses { get;  } = new List<Address>();

        /// <summary>
        /// Withes the first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <returns>A <see cref="ContactBuilder"/></returns>
        public ContactBuilder WithFirstName(string firstName)
        {
            BuilderEntity.FirstName = firstName;
            return this;
        }

        /// <summary>
        /// Withes the middle names.
        /// </summary>
        /// <param name="middleNames">The middle names.</param>
        /// <returns>A <see cref="ContactBuilder"/></returns>
        public ContactBuilder WithMiddleNames(string middleNames)
        {
            BuilderEntity.MiddleNames = middleNames;
            return this;
        }

        /// <summary>
        /// Withes the last name.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <returns>A <see cref="ContactBuilder"/></returns>
        public ContactBuilder WithLastName(string lastName)
        {
            BuilderEntity.LastName = lastName;
            return this;
        }

        /// <summary>
        /// Withes the company.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        public ContactBuilder WithCompany(string company)
        {
            BuilderEntity.Company = company;
            return this;
        }

        /// <summary>
        /// Withes the email address.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A <see cref="ContactBuilder"/></returns>
        public ContactBuilder WithEmailAddress(string emailAddress)
        {
            BuilderEntity.EmailAddress = emailAddress;
            return this;
        }

        /// <summary>
        /// Add an address to the contact.
        /// </summary>
        /// <param name="addressBuilder">The address builder.</param>
        /// <returns>A <see cref="ContactBuilder"/></returns>
        public ContactBuilder WithAddress(AddressBuilder addressBuilder)
        {
            BuilderEntity.Addresses.Add(addressBuilder.Build());
            return this;
        }
    }
}