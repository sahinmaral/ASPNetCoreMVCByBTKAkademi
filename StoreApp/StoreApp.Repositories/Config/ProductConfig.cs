using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entities;

namespace StoreApp.Repositories.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product() { Id = 1, Name = "Computer", Description = "Description about computer", Price = 17000, CategoryId = 1, ImageUrl = "4D6163E7-1321-4D07-8B38-9BF8A433A883.png" },
            new Product() { Id = 2, Name = "Keyboard", Description = "Description about keyboard", Price = 1000, CategoryId = 1, ImageUrl = "EA8FFAB5-7432-4D4C-8A49-C06FD536781C.png" },
            new Product() { Id = 3, Name = "Mouse", Description = "Description about mouse", Price = 1000, CategoryId = 1, ImageUrl = "2C2CD168-09B3-47EA-9F20-18CCD53C2A06.png" },
            new Product() { Id = 4, Name = "Monitor", Description = "Description about monitor", Price = 7000, CategoryId = 1, ImageUrl = "82471C75-0DE9-449B-9D71-58AFA425FD5B.png" },
            new Product() { Id = 5, Name = "Desk", Description = "Description about desk", Price = 1500, CategoryId = 2, ImageUrl = "ABEB5A52-0337-4A71-9A80-E659B8B589D6.png" },
            new Product() { Id = 6, Name = "Chair", Description = "Description about chair", Price = 2500, CategoryId = 2, ImageUrl = "56122ED3-A48C-43EA-8EEE-F71799E10947.png" }
        );
    }
}
