using System;
using System.Collections.Generic;
using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    public class AddressBuilder : BuilderBase<Address>
    {
        public AddressBuilder()
        {
            BuilderEntity.HouseNameOrNumber = DefaultHouseNameOrNumber;
            BuilderEntity.Street = DefaultStreet;
            BuilderEntity.TownCity = DefaultTownCity;
            BuilderEntity.County = DefaultCounty;
            BuilderEntity.PostCode = DefaultPostCode;
        }

        public static string DefaultHouseNameOrNumber { get; } = "42";

        public static string DefaultStreet { get; } = "The Street";

        public static string DefaultTownCity { get; } = "Small Town";

        public static string DefaultCounty { get; } = "Big County";

        public static string DefaultPostCode { get; } = "SM01 9BC";

        public AddressBuilder WithHouseNameOrNumber(string houseNumber)
        {
            BuilderEntity.HouseNameOrNumber = houseNumber;
            return this;
        }

        public AddressBuilder WithStreet(string street)
        {
            BuilderEntity.Street = street;
            return this;
        }

        public AddressBuilder WithTownCity(string townCity)
        {
            BuilderEntity.TownCity = townCity;
            return this;
        }

        public AddressBuilder WithPostCode(string postCode)
        {
            BuilderEntity.PostCode = postCode;
            return this;
        }
    }
}