namespace WSM.Catalog.Api.Models
{
    public class Base
    {
        public int? Limit { get; set; } = 100;
        public int? Offset { get; set; }
        public string? Sort { get; set; }
    }
}
