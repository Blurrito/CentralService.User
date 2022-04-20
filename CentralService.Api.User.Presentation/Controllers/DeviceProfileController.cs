using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.Factories.Managers;
using CentralService.Api.User.Interfaces.Managers;
using CentralService.Api.User.DTO.Api.User;

namespace CentralService.Api.User.Presentation.Controllers
{
    [ApiController]
    [Route("api/ds/device")]
    public class DeviceProfileController : ControllerBase
    {
        [HttpPost("profilecreate")]
        public async Task<ActionResult<ApiResponse?>> CreateProfile(DeviceProfile Profile)
        {
            try
            {
                ApiResponse? Response;
                using (IDeviceProfileManager Manager = DeviceProfileManagerFactory.GetManager())
                    Response = await Manager.CreateDeviceProfile(Profile);
                if (Response.HasValue)
                    return Ok(Response);
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse?>> NasLogin(string Address, DeviceProfile Profile)
        {
            try
            {
                ApiResponse? Response;
                using (IDeviceProfileManager Manager = DeviceProfileManagerFactory.GetManager())
                    Response = await Manager.NasLogin(Address, Profile);
                if (Response.HasValue)
                    return Ok(Response);
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
    }
}
