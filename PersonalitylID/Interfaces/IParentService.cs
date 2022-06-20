using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;

namespace PersonalityIdentification.Itrefaces
{
    public interface IParentService
    {
         Task<Parent> AddParent(Parent newParent);
         Task DeleteParent(int parentId);
         Task<List<PupilParent>> ListParentFromPupil(int id);
    }
}