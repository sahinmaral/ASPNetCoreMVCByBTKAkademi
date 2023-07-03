namespace StoreApp.Services.Abstract;

public interface IServiceManager
{
    IOrderService OrderService { get; }
    IProductService ProductService { get; }
    ICategoryService CategoryService { get; }
    IAuthService AuthService {get;}
}