using System;
using System.Collections.Generic;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    public class ContactBuilder : BuilderBase<Contact>
    {
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

        public static string DefaultFirstName { get; } = "Bob";

        public static string DefaultMiddleNames { get; } = null;

        public static string DefaultLastName { get; } = "Jones";

        public static string DefaultCompany { get; } = null;

        public static string DefaultEmailAddress { get; } = "bob.jones@email.com";

        public static IList<PhoneNumber> DefaultPhoneNumbers { get;  } = new List<PhoneNumber>();

        public static IList<Address> DefaultAddresses { get;  } = new List<Address>();

        public ContactBuilder WithFirstName(string firstName)
        {
            BuilderEntity.FirstName = firstName;
            return this;
        }

        public ContactBuilder WithMiddleNames(string middleNames)
        {
            BuilderEntity.MiddleNames = middleNames;
            return this;
        }

        public ContactBuilder WithLastName(string lastName)
        {
            BuilderEntity.LastName = lastName;
            return this;
        }

        public ContactBuilder WithCompany(string company)
        {
            BuilderEntity.Company = company;
            return this;
        }

        public ContactBuilder WithEmailAddress(string emailAddress)
        {
            BuilderEntity.EmailAddress = emailAddress;
            return this;
        }
    }
}