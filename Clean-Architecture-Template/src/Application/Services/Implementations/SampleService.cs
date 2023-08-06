using Application.DTOs;
using Application.Services.Interfaces;
using Domain.Repositories.UnitOfWork;

namespace Application.Services.Implementations
{
    public class SampleService : ISampleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SampleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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