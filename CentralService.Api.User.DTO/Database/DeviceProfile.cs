using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CentralService.Api.User.DTO.Database
{
    public class DeviceProfile
    {
        [Key]
        public int DeviceProfileId { get; set; }
        //public int UserId { get; set; }
        [Required]
        public long DeviceId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MacAddress { get; set; }
        public string DeviceName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public List<GameProfile> GameProfiles { get; set; }

        public DeviceProfile() { }

        public DeviceProfile(Api.User.DeviceProfile Profile)
        {
            DeviceProfileId = Profile.DeviceProfileId;
            DeviceId = Profile.DeviceId;
            Password = Profile.Password;
            MacAddress = Profile.MacAddress;
            DeviceName = Profile.DeviceName;
            CreatedDate = Profile.CreatedDate;

            GameProfiles = new List<GameProfile>();
            foreach (Api.User.GameProfile GameProfile in Profile.GameProfiles)
                GameProfiles.Add(new GameProfile(GameProfile.Gsbrcd, GameProfile.GameCode, DeviceId));
        }

        public void Update(Api.User.DeviceProfile Profile) => DeviceName = Profile.DeviceName;

        public Api.User.DeviceProfile ToDeviceProfileDTO()
        {
            List<Api.User.GameProfile> DTOGameProfiles = new List<Api.User.GameProfile>();
            foreach (GameProfile Profile in GameProfiles)
                DTOGameProfiles.Add(new Api.User.GameProfile(Profile.GameProfileId, DeviceProfileId, Profile.GameCode, Profile.Gsbrcd, Profile.FirstName,
                    Profile.LastName, Profile.Email, Profile.Nickname, Profile.UniqueNickname, Profile.Zipcode, Profile.Aim, Profile.Signature,
                    Profile.Pid, Profile.Longnitude, Profile.Lattitude, Profile.Location));
            return new Api.User.DeviceProfile(DeviceProfileId, DeviceId, Password, MacAddress, DeviceName, CreatedDate, DTOGameProfiles);
        }
    }
}
