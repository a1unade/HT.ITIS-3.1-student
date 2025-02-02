using Dotnet.Homeworks.Features.Products.Commands.DeleteProduct;
using Dotnet.Homeworks.Features.Products.Commands.InsertProduct;
using Dotnet.Homeworks.Features.Products.Commands.UpdateProduct;
using Dotnet.Homeworks.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet.Homeworks.MainProject.Controllers;

[ApiController]
public class ProductManagementController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductManagementController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("GetProducts")]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
        
        if (!result.IsSuccess) 
            return BadRequest(result);
        
        return Ok(result);
    }

    [HttpPost("InsertProduct")]
    public async Task<IActionResult> InsertProduct(string name, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new InsertProductCommand(name), cancellationToken);
        
        if (!result.IsSuccess)
            return BadRequest(result);
        
        return Ok(result.Value);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid guid, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteProductByGuidCommand(guid), cancellationToken);
        
        if (!result.IsSuccess)
            return BadRequest(result);
        
        return Ok(result);
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(Guid guid, string name, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateProductCommand(guid, name), cancellationToken);
        
        if (!result.IsSuccess)
            return BadRequest(result);
        
        return Ok(result);
    }
}