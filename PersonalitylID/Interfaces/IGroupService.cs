using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using System.Collections.Generic;
namespace PersonalityIdentification.Itrefaces
{
    public interface IGroupService
    {
         Task<Group> AddGroup(Group newGroup);
         Task<Group> AddPupilToGroup(GroupPupilDto newUser);
         Task DeleteGroup(int groupId);
         Task<List<Group>> ListGroup(int id);
    }
}