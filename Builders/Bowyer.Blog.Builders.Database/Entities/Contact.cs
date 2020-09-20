using System.Collections;
using System.Collections.Generic;

namespace Bowyer.Blog.Builders.Database.Entities
{
    public class Contact: ContactBase
    {
        public string FirstName { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public IList<PhoneNumber> PhoneNumbers { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}