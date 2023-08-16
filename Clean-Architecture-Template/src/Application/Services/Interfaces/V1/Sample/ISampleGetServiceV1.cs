namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleGetServiceV1
{
    Task<SampleDtoV1?> GetSampleById(long id);
}
