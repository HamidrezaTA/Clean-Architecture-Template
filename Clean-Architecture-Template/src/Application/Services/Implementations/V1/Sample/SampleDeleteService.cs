namespace Application.Services.Implementations.V1.Sample;

using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleDeleteService : ISampleDeleteService
{
    private readonly ISampleRepository _sampleRepository;

    public SampleDeleteService(ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
    }

    public Task DeleteSample(long id)
    {
        throw new NotImplementedException();
    }
}
