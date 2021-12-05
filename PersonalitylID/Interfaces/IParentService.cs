using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IParentService
    {
         Task<Parent> AddParent(Parent newParent);
         Task DeleteParent(int parentId);
    }
}