namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleCreateServiceV1 : ISampleCreateServiceV1
{
    private readonly ISampleRepository _sampleRepository;

    public SampleCreateServiceV1(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task CreateSample(SampleDtoV1 link)
    {
        throw new NotImplementedException();
    }
}
