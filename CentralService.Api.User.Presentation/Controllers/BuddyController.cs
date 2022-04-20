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
    [Route("api/ds/buddy")]
    public class BuddyController : ControllerBase
    {
        [HttpGet("getbuddylist")]
        public async Task<ActionResult<ApiResponse?>> GetBuddyList(int SenderId)
        {
            try
            {
                using (IBuddyManager Manager = BuddyManagerFactory.GetManager())
                    return Ok(await Manager.GetBuddies(SenderId));
            }
            catch
            {
                return BadRequest(new ApiResponse(false, null));
            }
        }

        [HttpGet("getincomingrequests")]
        public async Task<ActionResult<ApiResponse?>> GetIncomingRequests(int RecipientId)
        {
            try
            {
                using (IBuddyManager Manager = BuddyManagerFactory.GetManager())
                    return Ok(await Manager.GetIncomingRequests(RecipientId));
            }
            catch
            {
                return BadRequest(new ApiResponse(false, null));
            }
        }

        [HttpPost("addbuddy")]
        public async Task<ActionResult<ApiResponse?>> AddBuddy(string GameCode, Buddy Buddy)
        {
            try
            {
                using (IBuddyManager Manager = BuddyManagerFactory.GetManager())
                    return Ok(await Manager.AddBuddy(GameCode, Buddy));
            }
            catch 
            {
                return BadRequest(new ApiResponse(false, null));
            }
        }

        [HttpPut("updatebuddy")]
        public async Task<ActionResult> UpdateBuddy(Buddy Buddy)
        {
            try
            {
                using (IBuddyManager Manager = BuddyManagerFactory.GetManager())
                    await Manager.UpdateRequest(Buddy);
                return Ok();
            }
            catch
            {
                return BadRequest(new ApiResponse(false, null));
            }
        }

        [HttpDelete("deletebuddy")]
        public async Task<ActionResult> DeleteBuddy(int BuddyId)
        {
            try
            {
                using (IBuddyManager Manager = BuddyManagerFactory.GetManager())
                    await Manager.DeleteBuddy(BuddyId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
