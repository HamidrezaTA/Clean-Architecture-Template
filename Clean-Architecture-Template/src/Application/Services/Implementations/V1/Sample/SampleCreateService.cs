namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleCreateService : ISampleCreateService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleCreateService(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task CreateSample(SampleDto link)
    {
        throw new NotImplementedException();
    }
}
