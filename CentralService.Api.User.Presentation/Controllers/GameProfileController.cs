using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Api.User;
using CentralService.Api.User.Factories.Managers;
using CentralService.Api.User.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralService.Api.User.Presentation.Controllers
{
    [ApiController]
    [Route("api/ds/game")]
    public class GameProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ApiResponse?>> GetGameProfile(int GameProfileId)
        {
            try
            {
                ApiResponse? Response;
                using (IGameProfileManager Manager = GameProfileManagerFactory.GetManager())
                    Response = await Manager.GetGameProfile(GameProfileId);
                return Ok(Response);
            }
            catch (ArgumentException)
            {
                return BadRequest(new ApiResponse(false, null));
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch
            {
                return null;
            }
        }

        [HttpGet("getbuddyprofile")]
        public async Task<ActionResult<ApiResponse?>> GetBuddyProfile(int GameProfileId, string BuddyLastName)
        {
            try
            {
                ApiResponse? Response;
                using (IGameProfileManager Manager = GameProfileManagerFactory.GetManager())
                    Response = await Manager.GetGameProfile(GameProfileId);
                return Ok(Response);
            }
            catch (ArgumentException)
            {
                return BadRequest(new ApiResponse(false, null));
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch
            {
                return null;
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult> NasLogin(int SessionKey, GameProfile Profile)
        {
            try
            {
                using (IGameProfileManager Manager = GameProfileManagerFactory.GetManager())
                    await Manager.UpdateGameProfile(Profile);
                return Ok();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch
            {
                return null;
            }
        }
    }
}
