using Dotnet.Homeworks.Infrastructure.Cqrs.Queries;
using Dotnet.Homeworks.Infrastructure.UnitOfWork;
using Dotnet.Homeworks.Shared.Dto;

namespace Dotnet.Homeworks.Features.Products.Queries.GetProducts;

internal sealed class GetProductsQueryHandler: IQueryHandler<GetProductsQuery, GetProductsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    } 

    public async Task<Result<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var allProducts = await _unitOfWork.ProductRepository.GetAllProductsAsync(cancellationToken);
            var allProductsDto = allProducts.Select(p => new GetProductDto(p.Id, p.Name));

            return new Result<GetProductsDto>(new GetProductsDto(allProductsDto), true);
        }
        catch (Exception ex)
        {
            return new Result<GetProductsDto>(val: null, false, error: ex.Message);
        }
    }
}