namespace Bowyer.Blog.Builders.Database.Entities
{
    /// <summary>
    ///The Phone Number Entity
    /// </summary>
    /// <seealso cref="Bowyer.Blog.Builders.Database.Entities.ContactBase" />
    public class PhoneNumber : ContactBase
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }
    }
}