namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleCreateService
{
    Task CreateSample(SampleDto link);
}
