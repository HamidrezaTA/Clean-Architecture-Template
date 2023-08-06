using Application.DTOs;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/sample")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;
    private readonly ISampleService _sampleService;

    public SampleController(ILogger<SampleController> logger,
                            ISampleService sampleService)
    {
        _sampleService = sampleService;
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IEnumerable<SampleDto>> GetAll([FromQuery] SampleFilter filter)
    {
        return await _sampleService.GetByFilterAsync(filter);
    }

    [HttpGet("{id}")]
    public async Task<SampleDto> GetById([FromRoute] long id)
    {
        return await _sampleService.GetSampleById(id);
    }

    [HttpPost()]
    public async Task CreateSample([FromBody] SampleDto dto)
    {
        await _sampleService.CreateSample(dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteSample(long id)
    {
        await _sampleService.DeleteSample(id);
    }
}
