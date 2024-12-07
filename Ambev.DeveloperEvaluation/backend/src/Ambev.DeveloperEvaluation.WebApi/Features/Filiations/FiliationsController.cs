using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.ListFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.GetFiliation;
using Ambev.DeveloperEvaluation.Application.Filiations.GetFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

namespace Ambev.DeveloperEvaluation.WebApi.Filiations.Filiations;

[ApiController]
[Route("api/[controller]")]
public class FiliationsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IFiliationRepository _filiationRepository;

    public FiliationsController(IMediator mediator, IMapper mapper, IFiliationRepository filiationRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _filiationRepository = filiationRepository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateFiliationResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateFiliation([FromBody] CreateFiliationRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateFiliationRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateFiliationCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateFiliationResponse>
        {
            Success = true,
            Message = "Filiation created successfully",
            Data = _mapper.Map<CreateFiliationResponse>(response)
        });
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetFiliationResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFiliation([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetFiliationRequest { Id = id };
        var validator = new GetFiliationRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetFiliationCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetFiliationResponse>
        {
            Success = true,
            Message = "Filiation retrieved successfully",
            Data = _mapper.Map<GetFiliationResponse>(response)
        });
    }


    [HttpGet("/api/Filiations")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListFiliationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await _filiationRepository.ListAsync(cancellationToken);

        var list = result.Select(x => new ListFiliationResponse()
        {
            Id = x.Id.ToString(),
            Codigo = x.Codigo,
            Nome = x.Nome,
        });

        return Ok(new ApiResponseWithData<IEnumerable<ListFiliationResponse>>
        {
            Success = true,
            Message = "Filiation retrieved successfully",
            Data = list
        });
    }
}
