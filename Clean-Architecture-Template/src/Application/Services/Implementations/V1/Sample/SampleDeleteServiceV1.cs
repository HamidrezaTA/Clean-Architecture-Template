namespace Application.Services.Implementations.V1.Sample;

using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleDeleteServiceV1 : ISampleDeleteServiceV1
{
    private readonly ISampleRepository _sampleRepository;

    public SampleDeleteServiceV1(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task DeleteSample(long id)
    {
        throw new NotImplementedException();
    }
}
