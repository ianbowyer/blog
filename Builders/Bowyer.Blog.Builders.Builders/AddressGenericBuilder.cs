using System;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    /// <summary>
    /// The Address Builder
    /// </summary>
    public class AddressGenericBuilder : BuilderGenericBase<Address, AddressGenericBuilder>
    {
        public  AddressGenericBuilder()
            :base(BuilderConstants.DefaultAddress)
        {}
    }
}