using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPort.Domain.Models;
using TravelPort.Domain.Repository;
using TravelPort.Infrastructure.Db;

namespace TravelPort.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly TestDbContext _context;

        public PeopleRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<People> Add(People obj)
        {
            try
            {
                await _context.People.AddAsync(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            try
            {
                return await _context.People.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<People> GetById(int id)
        {
            try
            {
                var res = await _context.People.FirstAsync(f => f.Id.Equals(id));
                if (res != null)
                    return res;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                //var personToRemove = await _context.People.FirstAsync(f => f.Id.Equals(id));
                var personToRemove = await _context.People.FirstOrDefaultAsync(a => a.Id == id);

                _context.Remove(personToRemove);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<People> Update(People obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                var something = await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}