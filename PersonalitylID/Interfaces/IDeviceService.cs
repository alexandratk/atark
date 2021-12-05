using System.Threading.Tasks;
using PersonalityIdentification.DataContext;

namespace PersonalityIdentification.Itrefaces
{
    public interface IDeviceService
    {
         Task<Device> AddDevice(Device newDevice);
         Task DeleteDevice(int deviceId);
    }
}