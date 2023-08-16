namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Application.Validations;
using Domain.Repositories;
using FluentValidation;

public class SampleGetAllServiceV1 : ISampleGetAllServiceV1
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IValidator<SampleFilterV1> _validator;

    public SampleGetAllServiceV1(IValidator<SampleFilterV1> validator, ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
        _validator = validator;
    }
    public async Task<List<SampleDtoV1>> GetByFilterAsync(SampleFilterV1 filter)
    {
        await _validator.Validated(payload: filter);

        _sampleRepository.GetAll();

        throw new NotImplementedException();
    }

}
