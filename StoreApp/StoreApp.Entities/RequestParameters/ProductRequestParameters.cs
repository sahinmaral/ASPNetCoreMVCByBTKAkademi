namespace StoreApp.Entities.RequestParameters;

public class ProductRequestParameters : RequestParameters
{
    public int? CategoryId { get; set; }
    public int MinPrice { get; set; } = 0;
    public int MaxPrice { get; set; } = int.MaxValue;
    public bool IsValidPrice => MaxPrice > MinPrice;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 6;
}