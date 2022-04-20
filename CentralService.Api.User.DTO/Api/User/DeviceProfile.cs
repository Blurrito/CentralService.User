using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Api.User
{
    public struct DeviceProfile
    {
        public int DeviceProfileId { get; set; }
        public long DeviceId { get; set; }
        public string Password { get; set; }
        public string MacAddress { get; set; }
        public string DeviceName { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<GameProfile> GameProfiles { get; set; }

        public DeviceProfile(int DeviceProfileId, long DeviceId, string Password, string MacAddress, string DeviceName, DateTime CreatedDate, List<GameProfile> GameProfiles)
        {
            this.DeviceProfileId = DeviceProfileId;
            this.DeviceId = DeviceId;
            this.Password = Password;
            this.MacAddress = MacAddress;
            this.DeviceName = DeviceName;
            this.CreatedDate = CreatedDate;
            this.GameProfiles = GameProfiles;
        }
    }
}
