using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using XPRTZ_Binge_watch_api.Models;

namespace XPRTZ_Binge_watch_api.Data
{
    public class DataService : IDataService
    {
        private readonly XPRTZ_Binge_watch_apiContext _context;

        public DataService(XPRTZ_Binge_watch_apiContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<bool> Create(Show model)
        {
            var entry = _context.Add(model);
            await _context.SaveChangesAsync();

            return entry.State == EntityState.Added;
        }

        public async Task<bool> DeleteByID(int id)
        {
            var entry = _context.Remove(id);
            await _context.SaveChangesAsync();

            return entry.State == EntityState.Deleted;
        }

        public async Task<Show> FindById(int id)
        {
            return await _context.Show.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Show> FindByName(string name)
        {
            return await _context.Show.FirstOrDefaultAsync(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<List<Show>> GetAll()
        {
            return await _context.Show.ToListAsync();
        }

        public async Task UpdateByModel(Show model)
        {
            _context.Show.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
