namespace Infrastructure.Mapper.V1;

using Application.DTOs.V1;
using Application.Mapper.V1;
using Domain.Entities;
using Domain.Enums;

public class CustomMapper : IMapper
{
    public Sample MapSampleDtoToEntity(SampleDtoV1 linkDto)
    {
        return new Sample()
        {
            Title = linkDto.Title,
            Description = linkDto.Description,
            State = linkDto.State
        };
    }
}
