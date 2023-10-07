namespace Domain.ProductEvent
{
    public class RegisterEvent
    {
        public RegisterEvent(string type, int quantity, int totalQuantity, Guid productId, Guid branchId)
        {
            Type = type;
            Quantity = quantity;
            TotalQuantity = totalQuantity;
            ProductId = productId;
            BranchId = branchId;
        }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public int TotalQuantity { get; set; }

        public Guid ProductId { get; set; }

        public Guid BranchId { get; set; }
    }
}
