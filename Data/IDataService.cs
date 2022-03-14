using XPRTZ_Binge_watch_api.Models;

namespace XPRTZ_Binge_watch_api.Data
{
    public interface IDataService
    {
        Task<bool> Create(Show model);
        Task<bool> DeleteByID(int id);
        Task<Show> FindById(int id);
        Task<Show> FindByName(string name);
        Task<List<Show>> GetAll();
        Task UpdateByModel(Show model);
    }
}
