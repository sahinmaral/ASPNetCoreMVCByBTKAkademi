using System.Text.Json.Serialization;
using StoreApp.Entities;
using StoreApp.Web.Infrastructure.Extensions;

namespace StoreApp.Web.Models;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession? Session { get; set; }

    public static Cart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()
        .HttpContext?.Session;

        SessionCart cart = session?.GetObject<SessionCart>("cart") ?? new SessionCart();
        cart.Session = session;

        return cart;
    }

    public override void AddItem(Product product, int quantity)
    {
        base.AddItem(product, quantity);

        Session?.SetObject("cart",this);
    }

    public override void Clear()
    {
        base.Clear();

        Session?.Remove("cart");
    }

    public override void RemoveLine(Product product)
    {
        base.RemoveLine(product);

        Session?.SetObject("cart",this);
    }
}