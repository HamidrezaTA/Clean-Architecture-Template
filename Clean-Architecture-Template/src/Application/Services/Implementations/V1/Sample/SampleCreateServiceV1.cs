namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Mapper.V1;
using Application.MessageBus;
using Application.Services.Interfaces.V1.Sample;
using Domain.Entities;
using Domain.Repositories;

public class SampleCreateServiceV1 : ISampleCreateServiceV1
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IMessagePublisherBuilder _messagePublisher;
    private readonly IMapper _mapper;

    public SampleCreateServiceV1(ISampleRepository sampleRepository,
                                 IMessagePublisherBuilder messagePublisher,
                                 IMapper mapper)
    {
        _mapper = mapper;
        _messagePublisher = messagePublisher;
        _sampleRepository = sampleRepository;
    }

    public async Task CreateSample(SampleDtoV1 linkDto)
    {
        Sample entity = _mapper.MapSampleDtoToEntity(linkDto);
        await _sampleRepository.AddAsync(entity);
    }

    public async Task PublishCreateSampleMessage(SampleDtoV1 dto)
    {
        await _messagePublisher.SetQueue("sample-queue", false, false)
                               .SetExchange("sample-exchange", "direct", false)
                               .QueueBindToExchange("sample-routing-key")
                               .PublishAsync(dto);
    }
}
