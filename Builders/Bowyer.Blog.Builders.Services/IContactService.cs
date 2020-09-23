using System.Collections.Generic;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Services
{
    /// <summary>
    /// The Contact Service Interface
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IList<Contact> GetAll(string filter);
    }
}