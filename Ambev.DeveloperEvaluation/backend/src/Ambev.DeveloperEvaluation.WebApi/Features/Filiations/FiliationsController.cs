using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiations.ListFiliation;

namespace Ambev.DeveloperEvaluation.WebApi.Filiations.Filiations;

[ApiController]
[Route("api/[controller]")]
public class FiliaitionsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IFiliationRepository _filiationRepository;

    public FiliaitionsController(IMediator mediator, IMapper mapper, IFiliationRepository filiationRepository)
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

    [HttpGet("/api/Filiations")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListFiliationResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await _filiationRepository.ListAsync(cancellationToken);

        var list = result.Select(x => new ListFiliationResponse()
        {
            Id = x.Id.ToString(),
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
