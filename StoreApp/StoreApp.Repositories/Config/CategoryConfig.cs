using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entities;

namespace StoreApp.Repositories.Config;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Category furnitureCategory = new Category() { Id = 2, Name = "Furnitures" };
        Category electronicCategory = new Category() { Id = 1, Name = "Electronics" };

        builder.HasData(furnitureCategory, electronicCategory);

        builder.HasMany(e => e.Products)
            .WithOne(e => e.Category)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired();
    }
}
