namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleUpdateService
{
    Task UpdateSample(SampleDto link);
}
