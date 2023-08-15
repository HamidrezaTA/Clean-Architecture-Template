namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleGetService : ISampleGetService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleGetService(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task<SampleDto?> GetSampleById(long id)
    {
        throw new NotImplementedException();
    }
}
