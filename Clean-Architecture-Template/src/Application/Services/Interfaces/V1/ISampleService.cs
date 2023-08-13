namespace Application.Services.Interfaces.V1;

using Application.DTOs.V1;

public interface ISampleService
{
    Task<SampleDto?> GetSampleById(long id);
    Task CreateSample(SampleDto link);
    Task UpdateSample(SampleDto link);
    Task DeleteSample(long id);
    Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter);
}
