namespace Application.Services.Implementations.V1;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1;
using Domain.Repositories;

public class SampleService : ISampleService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleService(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task CreateSample(SampleDto link)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSample(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<SampleDto?> GetSampleById(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSample(SampleDto link)
    {
        throw new NotImplementedException();
    }
}
