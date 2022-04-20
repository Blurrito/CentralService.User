using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string ImagePath { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<DeviceProfile> LinkedDevices { get; set; }
    }
}
