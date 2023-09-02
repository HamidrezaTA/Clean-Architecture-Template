using Application.DTOs.V1;
using Domain.Entities;

namespace Application.Mapper.V1;

public interface IMapper
{
    Sample MapSampleDtoToEntity(SampleDtoV1 linkDto);
}
