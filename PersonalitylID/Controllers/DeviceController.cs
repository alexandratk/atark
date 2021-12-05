using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalityIdentification.DataContext;
using PersonalityIdentification.Dtos;
using PersonalityIdentification.Itrefaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace PersonalityIdentification.Controllers
{
    // http://localhost:5000/[controllernmae]/apiName

    [ApiController]
    [Route("[controller]")]
    public class DeviceController: ControllerBase 
    {
        private readonly IDeviceService deviceService;
        private readonly IMapper mapper;
        private readonly MyDataContext context;

        public DeviceController(MyDataContext context, IDeviceService deviceService,
         IMapper mapper) {
             this.context = context;
             this.deviceService = deviceService;
             this.mapper = mapper;
         }


        [Authorize(Roles = "SuperAdministrator")]
        [HttpPost("adddevice")]
        public async Task<IActionResult> RegisterDevice([FromBody] DeviceDto deviceDto)
        {
            EducationalInstitution timeEducationalInstitution = context.EducationalInstitution.Where(c => c.Id == deviceDto.EducationalInstitutionId).FirstOrDefault();
            Device newDevice = mapper.Map<Device>(deviceDto);
            newDevice.EducationalInstitution = timeEducationalInstitution;
            newDevice = await deviceService.AddDevice(newDevice);
            return Ok(newDevice);
        }

        [Authorize(Roles = "SuperAdministrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            await deviceService.DeleteDevice(id);
            return Ok(new
            {
               Response = "Device is deleted successfully"
            });
        }
    }
}