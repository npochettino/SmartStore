namespace SmartStore.Domain.Entities
{
    public class Product : BaseEntity
    {
        private Product()
        {
            
        }

        public Product(Guid id, string name, decimal price, bool? isAvailable = true)
        {
            InitializeProduct(id, name, price, isAvailable);
        }

        public Product(string name, decimal price, bool? isAvailable = true)
        {
            InitializeProduct(Guid.NewGuid(), name, price, isAvailable);
        }

        private void InitializeProduct(Guid id, string name, decimal price, bool? isAvailable)
        {
            Id = id;
            Name = name;
            Price = price;
            IsAvailable = isAvailable ?? false;
            SalesCount = 0;
        }

        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public bool IsAvailable { get; private set; }
        public int SalesCount { get; private set; }

        public void MarkAsSoldOut() => IsAvailable = false;
        public void AddSeles(int sales) => SalesCount = SalesCount + sales;
        public void SetName(string name) => Name = name;
        public void SetPrice(decimal price) => Price = price;
    }
}
