using StoreApp.Entities.Abstract;

namespace StoreApp.Entities;

public class Category : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; } = String.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}