namespace Bowyer.Blog.Builders.Database.Entities
{
    public class Address : ContactBase
    {
        public string HouseNameOrNumber { get; set; }
        public string Street { get; set; }
        public string TownCity { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
    }
}