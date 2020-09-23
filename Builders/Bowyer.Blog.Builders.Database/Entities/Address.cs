namespace Bowyer.Blog.Builders.Database.Entities
{
    /// <summary>
    /// The Address Entity.
    /// </summary>
    /// <seealso cref="Bowyer.Blog.Builders.Database.Entities.ContactBase" />
    public class Address : ContactBase
    {
        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the house name or number.
        /// </summary>
        public string HouseNameOrNumber { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the town city.
        /// </summary>
        public string TownCity { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        public string PostCode { get; set; }
    }
}