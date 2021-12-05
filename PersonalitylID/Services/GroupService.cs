using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Collections.Generic;

namespace PersonalityIdentification.Services
{
    public class GroupService: IGroupService
    {
        private readonly MyDataContext database;

        public GroupService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Group> AddGroup(Group newGroup)
        {
            await database.Group.AddAsync(newGroup);
            await database.SaveChangesAsync();

            return newGroup;
        }

        public async Task<Group> AddPupilToGroup(GroupPupilDto newPupil)
        {
            var currentGroup = await database.Group.Include(p => p.Pupils).FirstOrDefaultAsync(u => u.Id == newPupil.GroupId);
            var currentPupil = await database.Pupil.FirstOrDefaultAsync(p => p.Id == newPupil.PupilId);

            if (currentPupil == null || currentGroup == null)
            {
                throw new System.Exception("Group or pupil is null");
            }

            if (currentGroup.Pupils.Any(p => p.Id == currentPupil.Id))
            {
                throw new System.Exception("This pupil is already assigned to Group");
            }

            currentGroup.Pupils.Add(currentPupil);

            database.Update(currentGroup);

            await database.SaveChangesAsync();

            return currentGroup;
        }

        public async Task DeleteGroup(int GroupId)
        {
            var deletingGroupDescription =
             await database.Group.FirstOrDefaultAsync(p => p.Id == GroupId);

            if (deletingGroupDescription is null)
                throw new System.Exception("No proper group found");

            database.Group.Remove(deletingGroupDescription);
            await database.SaveChangesAsync();

        }


        public async Task<List<Group>> ListGroup(int id) {
            var users = (from user in database.Group.Include("EducationalInstitution")
                            where user.EducationalInstitution.Id == id
                             select user).ToList();
             return users;
        }
    }
}