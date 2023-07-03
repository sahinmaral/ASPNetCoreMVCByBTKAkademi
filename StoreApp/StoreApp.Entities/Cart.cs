namespace StoreApp.Entities;

public class Cart
{
    public Cart()
    {
        CartLines = new List<CartLine>();
    }

    public List<CartLine> CartLines { get; set; }

    public virtual void AddItem(Product product, int quantity)
    {
        CartLine? line = CartLines.Where(x => x.Product.Id == product.Id).FirstOrDefault();
        if (line is null)
        {
            CartLines.Add(new CartLine() { Product = product, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }
    public virtual void RemoveLine(Product product) => CartLines.RemoveAll(x => x.Product.Id == product.Id);
    public decimal ComputeTotalValue() => CartLines.Sum(x => x.Product.Price * x.Quantity);
    public virtual void Clear() => CartLines.Clear();
}