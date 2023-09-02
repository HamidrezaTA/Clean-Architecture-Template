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
    public async Task<IEnumerable<SampleDtoV1>> GetAll([FromQuery] SampleFilterV1 filter, ISampleGetAllServiceV1 sampleGetAllService)
    {
        return await sampleGetAllService.GetByFilterAsync(filter);
    }

    [HttpGet("{id}")]
    public async Task<SampleDtoV1> GetById([FromRoute] long id, ISampleGetServiceV1 sampleGetService)
    {
        return await sampleGetService.GetSampleById(id);
    }

    [HttpPost()]
    public async Task CreateSample([FromBody] SampleDtoV1 dto, ISampleCreateServiceV1 sampleCreateService)
    {
        await sampleCreateService.CreateSample(dto);
    }

    [HttpPost("publish-create-message")]
    public async Task PublishCreateMessage([FromBody] SampleDtoV1 dto, ISampleCreateServiceV1 sampleCreateService)
    {
        await sampleCreateService.PublishCreateSampleMessage(dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteSample(long id, ISampleDeleteServiceV1 sampleDeleteService)
    {
        await sampleDeleteService.DeleteSample(id);
    }
}
