namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleGetAllServiceV1
{
    Task<List<SampleDtoV1>> GetByFilterAsync(SampleFilterV1 filter);
}
