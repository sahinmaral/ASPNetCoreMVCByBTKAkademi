using System.ComponentModel.DataAnnotations;

namespace StoreApp.Web.Models
{
    public class ProductUpdateViewModel
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; init; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "Price {0} must be greater than {1}.")]
        public decimal Price { get; init; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; init; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; init; }
        public bool CanBeShownInShowcase { get; set; }
    }
}
