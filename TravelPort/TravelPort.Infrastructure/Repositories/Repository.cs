using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPort.Domain.Repository;
using TravelPort.Infrastructure.Db;

namespace TravelPort.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TestDbContext _context;

        public Repository(TestDbContext context)
        {
            _context = context;
        }

        public Task<T> Add(T obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}