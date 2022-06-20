using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;

namespace PersonalityIdentification.Itrefaces
{
    public interface IAdministratorService
    {
        Task<Administrator> AddAdministrator(Administrator newAdministrator);
        Task<Administrator> GetEducInst(int id);
        Task DeleteAdministrator(int administratorId);
        Task<List<Administrator>> ListAdmin(int id);
        
    }
}