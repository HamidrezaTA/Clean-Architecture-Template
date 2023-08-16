namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleUpdateServiceV1
{
    Task UpdateSample(SampleDtoV1 link);
}
