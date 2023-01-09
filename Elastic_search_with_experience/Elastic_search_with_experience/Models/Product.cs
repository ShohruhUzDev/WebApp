namespace Elastic_search_with_experience.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int  Price { get; set; }
        public int  Quantity { get; set; }
        public string Measurement { get; set; }
        public string Unit { get; set; }
        public bool ShowPrice { get; set; }



    }
}
