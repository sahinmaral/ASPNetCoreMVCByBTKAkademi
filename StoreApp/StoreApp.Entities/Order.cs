using System.ComponentModel.DataAnnotations;
using StoreApp.Entities.Abstract;

namespace StoreApp.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public ICollection<CartLine> CartLines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Line is required")]
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Line3 { get; set; }
    public string? City { get; set; }
    public bool MustOrderWrappedAsGift { get; set; }
    public bool IsShipped { get; set; }
    public DateTime OrderedAt { get; set; } = DateTime.Now;
}