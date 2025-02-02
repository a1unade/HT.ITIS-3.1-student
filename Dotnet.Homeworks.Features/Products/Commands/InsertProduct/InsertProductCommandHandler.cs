using Dotnet.Homeworks.Domain.Entities;
using Dotnet.Homeworks.Infrastructure.Cqrs.Commands;
using Dotnet.Homeworks.Infrastructure.UnitOfWork;
using Dotnet.Homeworks.Shared.Dto;

namespace Dotnet.Homeworks.Features.Products.Commands.InsertProduct;

internal sealed class InsertProductCommandHandler: ICommandHandler<InsertProductCommand, InsertProductDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public InsertProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<InsertProductDto>> Handle(InsertProductCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentNullException(nameof(request.Name));
            
            var newProduct = new Product { Name = request.Name };

            var productGuid = await _unitOfWork.ProductRepository.InsertProductAsync(newProduct, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new Result<InsertProductDto>(new InsertProductDto(productGuid), true);
        }
        catch (Exception ex)
        {
            return new Result<InsertProductDto>(null, false, error: ex.Message);
        }
    }
}