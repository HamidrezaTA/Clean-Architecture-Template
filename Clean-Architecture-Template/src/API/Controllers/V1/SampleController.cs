namespace API.Controllers.V1;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/sample")]
[ApiVersion("1.0")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IEnumerable<SampleDto>> GetAll([FromQuery] SampleFilter filter, ISampleGetAllService sampleGetAllService)
    {
        return await sampleGetAllService.GetByFilterAsync(filter);
    }

    [HttpGet("{id}")]
    public async Task<SampleDto> GetById([FromRoute] long id, ISampleGetService sampleGetService)
    {
        return await sampleGetService.GetSampleById(id);
    }

    [HttpPost()]
    public async Task CreateSample([FromBody] SampleDto dto, ISampleCreateService sampleCreateService)
    {
        await sampleCreateService.CreateSample(dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteSample(long id, ISampleDeleteService sampleDeleteService)
    {
        await sampleDeleteService.DeleteSample(id);
    }
}
