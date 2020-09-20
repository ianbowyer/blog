using System;
using System.Collections.Generic;
using System.Text;

namespace Bowyer.Blog.Builders.Database.Entities
{
    public abstract class ContactBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}