namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleGetAllService
{
    Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter);
}
