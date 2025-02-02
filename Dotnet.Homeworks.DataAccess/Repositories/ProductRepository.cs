using Dotnet.Homeworks.Data.DatabaseContext;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Homeworks.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task DeleteProductByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products
                          .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (product is null)
            throw new ArgumentException("Product not found");

        _dbContext.Products.Remove(product);
    }

    public Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Products.Update(product);
        
        return Task.CompletedTask;
    }

    public async Task<Guid> InsertProductAsync(Product product, CancellationToken cancellationToken)
    {
        var checkProduct = await _dbContext.Products
            .FirstOrDefaultAsync(x => x.Id == product.Id, cancellationToken);
        
        if (checkProduct is not null)
            throw new ArgumentException("Product already exists");
        
        await _dbContext.Products.AddAsync(product, cancellationToken);
        
        return product.Id;
    }
}