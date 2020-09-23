using Bowyer.Blog.Builders.Database.Entities;

namespace Bowyer.Blog.Builders.Builders
{
    /// <summary>
    /// The Address Builder
    /// </summary>
    public class AddressBuilder : BuilderBase<Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBuilder"/> class.
        /// </summary>
        public AddressBuilder()
        {
            BuilderEntity.HouseNameOrNumber = DefaultHouseNameOrNumber;
            BuilderEntity.Street = DefaultStreet;
            BuilderEntity.TownCity = DefaultTownCity;
            BuilderEntity.County = DefaultCounty;
            BuilderEntity.PostCode = DefaultPostCode;
        }

        /// <summary>
        /// Gets the default house name or number.
        /// </summary>
        public static string DefaultHouseNameOrNumber { get; } = "42";

        /// <summary>
        /// Gets the default street.
        /// </summary>
        public static string DefaultStreet { get; } = "The Street";

        /// <summary>
        /// Gets the default town city.
        /// </summary>
        public static string DefaultTownCity { get; } = "Small Town";

        /// <summary>
        /// Gets the default county.
        /// </summary>
        public static string DefaultCounty { get; } = "Big County";

        /// <summary>
        /// Gets the default post code.
        /// </summary>
        public static string DefaultPostCode { get; } = "SM01 9BC";

        /// <summary>
        /// Sets the house name or number.
        /// </summary>
        /// <param name="houseNumber">The house number.</param>
        /// <returns>A <see cref="AddressBuilder"/></returns>
        public AddressBuilder WithHouseNameOrNumber(string houseNumber)
        {
            BuilderEntity.HouseNameOrNumber = houseNumber;
            return this;
        }

        /// <summary>
        /// Sets the street.
        /// </summary>
        /// <param name="street">The street.</param>
        /// <returns>A <see cref="AddressBuilder"/></returns>
        public AddressBuilder WithStreet(string street)
        {
            BuilderEntity.Street = street;
            return this;
        }

        /// <summary>
        /// Sets the town city.
        /// </summary>
        /// <param name="townCity">The town city.</param>
        /// <returns>A <see cref="AddressBuilder"/></returns>
        public AddressBuilder WithTownCity(string townCity)
        {
            BuilderEntity.TownCity = townCity;
            return this;
        }

        /// <summary>
        /// Sets the post code.
        /// </summary>
        /// <param name="postCode">The post code.</param>
        /// <returns>A <see cref="AddressBuilder"/></returns>
        public AddressBuilder WithPostCode(string postCode)
        {
            BuilderEntity.PostCode = postCode;
            return this;
        }
    }
}