namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.MessageBus;
using Application.Services.Interfaces.V1.Sample;
using Domain.Repositories;

public class SampleCreateServiceV1 : ISampleCreateServiceV1
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IMessagePublisher _messagePublisher;

    public SampleCreateServiceV1(ISampleRepository sampleRepository,
                                 IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
        _sampleRepository = sampleRepository;
    }

    public Task CreateSample(SampleDtoV1 link)
    {
        throw new NotImplementedException();
    }

    public Task PublishCreateSampleMessage()
    {
        _messagePublisher.Publish();

        throw new NotImplementedException();
    }
}
