using System.Threading.Tasks;
using PersonalityIdentification.DataContext;
using System.Collections.Generic;
namespace PersonalityIdentification.Itrefaces
{
    public interface IDeviceService
    {
        Task<Device> AddDevice(Device newDevice);
        Task DeleteDevice(int deviceId);
        Task<List<Device>> ListDevice();
        Task<List<Device>> ListDeviceFromEducinst(int id);
        Task<Device> GetsDeviceById(int id);
        Task<EducationalInstitution> GetsEducinstById(int id);
        Task<Device> UpdateDevice(Device userInfo, int id);
    }
}