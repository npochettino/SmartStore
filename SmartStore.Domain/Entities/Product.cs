namespace SmartStore.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SalesCount { get; set; }

        public void MarkAsSoldOut() => IsAvailable = false;
    }
}
