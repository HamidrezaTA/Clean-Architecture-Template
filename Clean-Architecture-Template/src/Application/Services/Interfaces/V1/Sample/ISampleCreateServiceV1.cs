namespace Application.Services.Interfaces.V1.Sample;

using Application.DTOs.V1;

public interface ISampleCreateServiceV1
{
    Task CreateSample(SampleDtoV1 link);
    Task PublishCreateSampleMessage(SampleDtoV1 dto);
}
