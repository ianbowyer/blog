using System;
using System.Collections.Generic;
using System.Text;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    public static class BuilderConstants
    {
        public static Address DefaultAddress = new Address
        {
            HouseNameOrNumber = "42",
            Street = "The Street",
            TownCity = "Small Town",
            County = "Big County",
            PostCode = "SM01 9BC",
        };
    }
}