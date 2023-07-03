using StoreApp.Entities;

namespace StoreApp.Repositories.Extensions;

public static class ProductRepositoryExtension
{
    public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
    {
        if (categoryId is null) return products;
        return products.Where(prd => prd.CategoryId == categoryId);
    }

    public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm)) return products;
        return products.Where(pr => pr.Name.ToLower().Contains(searchTerm.ToLower()));
    }

    public static IQueryable<Product> FilteredByMinAndMaxPrice(this IQueryable<Product> products, int minPrice, int maxPrice, bool isValidPrice)
    {
        if (isValidPrice)
            return products.Where(pr => pr.Price >= minPrice && pr.Price <= maxPrice);
        return products;
    }

    public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
    {
        return products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}