using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IPupilParentService
    {
         Task<PupilParent> AddPupilParent(PupilParent newPupilParent);
         Task DeletePupilParent(int pupilParentId);
    }
}