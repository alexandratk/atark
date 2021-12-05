using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Helpers;

namespace PersonalityIdentification.Itrefaces
{
    public interface IAuthService
    {
         Task<AuthResponseModel> AuthUser(AuthRequestModel authRequestModel);
         Task<User> findRequest(int id, string role);
    }
}