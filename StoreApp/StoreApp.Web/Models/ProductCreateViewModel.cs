using System.ComponentModel.DataAnnotations;

namespace StoreApp.Web.Models
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; init; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "Price {0} must be greater than {1}.")]
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; init; }
        public string? ImageUrl { get; set; }
    }
}
