namespace API.Controllers.V1;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1;
using Application.Services.Interfaces.V1.Sample;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/sample")]
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
    public async Task<IEnumerable<SampleDto>> GetAll([FromQuery] SampleFilter filter, ISampleGetAllService sampleGetAllService)
    {
        return await sampleGetAllService.GetByFilterAsync(filter);
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
