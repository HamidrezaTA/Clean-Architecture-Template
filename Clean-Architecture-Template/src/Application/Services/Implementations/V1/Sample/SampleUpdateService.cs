namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleUpdateService : ISampleUpdateService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleUpdateService(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task UpdateSample(SampleDto link)
    {
        throw new NotImplementedException();
    }
}
