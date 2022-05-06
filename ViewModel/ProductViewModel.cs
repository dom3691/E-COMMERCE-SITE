namespace Ecomm.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Featured { get; set; }
        public int NumberOfSale { get; set; }
        public int Ratings { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal DiscountedUnitPrice { get; set; }
        public int PercentOff { get; set; }
        public int Quantity { get; set; }
        public bool Availability { get; set; }
    }
}
