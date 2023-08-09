using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public Task CreateSample(SampleDto link)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSample(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SampleDto>> GetByFilterAsync(SampleFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<SampleDto?> GetSampleById(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSample(SampleDto link)
        {
            throw new NotImplementedException();
        }
    }
}