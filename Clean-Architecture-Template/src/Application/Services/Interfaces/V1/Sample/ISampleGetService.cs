namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleGetService
{
    Task<SampleDto?> GetSampleById(long id);
}
