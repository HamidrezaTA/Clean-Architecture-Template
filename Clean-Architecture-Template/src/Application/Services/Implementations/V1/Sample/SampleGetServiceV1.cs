namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleGetServiceV1 : ISampleGetServiceV1
{
    private readonly ISampleRepository _sampleRepository;

    public SampleGetServiceV1(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task<SampleDtoV1?> GetSampleById(long id)
    {
        throw new NotImplementedException();
    }
}
