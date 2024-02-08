namespace EcommerceManagementProject.Models.Dto
{
    public class CartProductDto
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductImageURL { get; set; }
    }
}
