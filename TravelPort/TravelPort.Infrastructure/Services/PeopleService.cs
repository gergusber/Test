using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPort.Domain.Models;
using TravelPort.Domain.Repository;
using TravelPort.Domain.Service;

namespace TravelPort.Infrastructure.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repo;

        public PeopleService(IPeopleRepository repo)
        {
            _repo = repo;
        }

        public async Task<People> Add(People obj) => await _repo.Add(obj);

        public async Task<IEnumerable<People>> GetAll() => await _repo.GetAll();

        public async Task<People> GetById(int id) => await _repo.GetById(id);

        public async Task Remove(int id) => await _repo.Remove(id);

        public async Task<People> Update(People obj) => await _repo.Update(obj);
    }
}