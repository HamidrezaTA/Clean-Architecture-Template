namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleUpdateServiceV1 : ISampleUpdateServiceV1
{
    private readonly ISampleRepository _sampleRepository;

    public SampleUpdateServiceV1(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task UpdateSample(SampleDtoV1 link)
    {
        throw new NotImplementedException();
    }
}
