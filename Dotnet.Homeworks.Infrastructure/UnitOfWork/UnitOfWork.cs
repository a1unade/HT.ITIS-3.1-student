using Dotnet.Homeworks.Data.DatabaseContext;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;

namespace Dotnet.Homeworks.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public IProductRepository ProductRepository { get; set; }
    
    public UnitOfWork(IProductRepository productRepository, AppDbContext dbContext)
    {
        ProductRepository = productRepository;
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken token)
    {
        await _dbContext.SaveChangesAsync(token);
    }
}