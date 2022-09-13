using League_Management_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace League_Management_Data.Repositories.Abstractions
{
    public interface IManagerRepository
    {
        Task<bool> AddManagerAsync(Manager managerFromDTO);
        Task<bool> DeleteManagerAsync(string managerId);
        Task<Manager> GetManagerAsync(string managerId);
        Task<Manager> GetManagerByEmailAsync(string managerEmail);
        Task<IEnumerable<Team>> GetManagersPreviousTeamsAsync(string managerId);
    }
}