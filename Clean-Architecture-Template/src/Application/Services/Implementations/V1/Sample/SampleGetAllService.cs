namespace Application.Services.Implementations.V1.Sample;

using Application.DTOs.V1;
using Application.Services.Interfaces.V1.Sample;
using Application.Validations;
using Domain.Repositories;
using FluentValidation;

public class SampleGetAllService: ISampleGetAllService
{
    private readonly ISampleRepository _sampleRepository;
    private readonly IValidator<SampleFilter> _validator;

    public SampleGetAllService(IValidator<SampleFilter> validator, ISampleRepository sampleRepository)
    {
        _sampleRepository = sampleRepository;
        _validator = validator;
    }
    public async Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter)
    {
        await _validator.Validated(payload: filter);

        _sampleRepository.GetAll();

        throw new NotImplementedException();
    }

}
