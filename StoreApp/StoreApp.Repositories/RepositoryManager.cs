using StoreApp.Repositories.Abstract;

namespace StoreApp.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IProductRepository _productRepository;
    private readonly StoreAppDbContext _dbContext;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IOrderRepository _orderRepository;

    public RepositoryManager(IProductRepository productRepository, StoreAppDbContext dbContext, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _dbContext = dbContext;
        _categoryRepository = categoryRepository;
        _orderRepository = orderRepository;
    }

    public IProductRepository ProductRepository => _productRepository;

    public ICategoryRepository CategoryRepository => _categoryRepository;

    public IOrderRepository OrderRepository => _orderRepository;

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}