using StoreApp.Entities.Abstract;

namespace StoreApp.Entities;
public class Product : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; } = String.Empty;
    public string? Description { get; set; } = String.Empty;
    public string? ImageUrl { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool CanBeShownInShowcase { get; set; }
}
