using Application.DTOs;

namespace Application.Services.Interfaces;

public interface ISampleService
{
    Task<SampleDto?> GetSampleById(long id);
    Task CreateSample(SampleDto link);
    Task UpdateSample(SampleDto link);
    Task DeleteSample(long id);
    Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter);
}