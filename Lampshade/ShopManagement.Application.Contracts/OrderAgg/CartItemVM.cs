namespace ShopManagement.Application.Contracts.OrderAgg
{
    public class CartItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Picture { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }

        public void CalculateTotalPrice() => TotalPrice = UnitPrice * Count;
        

    }
}
