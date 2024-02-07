namespace EcommerceManagementProject.Models.Dto
{
    public class FavoProductDto
    {
        public Guid FavId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }


        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductImageURL { get; set; }
    }
}
