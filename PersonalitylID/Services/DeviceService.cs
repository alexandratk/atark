using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Itrefaces;
using System.Collections.Generic;
using System.Linq;

namespace PersonalityIdentification.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly MyDataContext database;

        public DeviceService(MyDataContext database)
        {
            this.database = database;
        }

        public async Task<Device> AddDevice(Device newDevice)
        {
            await database.Device.AddAsync(newDevice);
            await database.SaveChangesAsync();

            return newDevice;
        }

        public async Task DeleteDevice(int DeviceId)
        {
            var deletingDeviceDescription =
             await database.Device.FirstOrDefaultAsync(p => p.Id == DeviceId);

            if (deletingDeviceDescription is null)
                throw new System.Exception("No proper place found");

            database.Device.Remove(deletingDeviceDescription);
            await database.SaveChangesAsync();

        }

        public async Task<List<Device>> ListDevice() {
            var users = (from user in database.Device select user).ToList();
             return users;
        }

        public async Task<List<Device>> ListDeviceFromEducinst(int id) {
            var users = (from user in database.Device.Include("EducationalInstitution")
                            where user.EducationalInstitution.Id == id
                             select user).ToList();
             return users;
        }


        public async Task<Device> GetsDeviceById(int id)
        {
            var users = await database.Device.Include(u => u.EducationalInstitution).FirstOrDefaultAsync(u => u.Id == id);
            
             return users;
        }

        
        public async Task<EducationalInstitution> GetsEducinstById(int id)
        {
            var users = await database.EducationalInstitution.FirstOrDefaultAsync(u => u.Id == id);
             return users;
        }

        public async Task<Device> UpdateDevice(Device userInfo, int id)
        {
            database.Update(userInfo);
            await database.SaveChangesAsync();

            return userInfo;
        }
    }
}