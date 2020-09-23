using System;

namespace Bowyer.Blog.Builders.Database.Entities
{
    /// <summary>
    /// The Contact Base
    /// </summary>
    public abstract class ContactBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }
    }
}