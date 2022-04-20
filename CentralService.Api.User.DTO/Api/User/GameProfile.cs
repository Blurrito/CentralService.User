using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Api.User
{
    public struct GameProfile
    {
        public int GameProfileId { get; set; }
        public int DeviceProfileId { get; set; }
        public string GameCode { get; set; }
        public string Gsbrcd { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string UniqueNickname { get; set; }
        public string Zipcode { get; set; }
        public string Aim { get; set; }
        public string Signature { get; set; }
        public int Pid { get; set; }
        public float Longnitude { get; set; }
        public float Lattitude { get; set; }
        public string Location { get; set; }

        public GameProfile(int GameProfileId, int DeviceProfileId, string GameCode, string Gsbrcd, string FirstName, string LastName,
            string Email, string Nickname, string UniqueNickname, string Zipcode, string Aim, string Signature,
            int Pid, float Longnitude, float Lattitude, string Location)
        {
            this.GameProfileId = GameProfileId;
            this.DeviceProfileId = DeviceProfileId;
            this.GameCode = GameCode;
            this.Gsbrcd = Gsbrcd;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Nickname = Nickname;
            this.UniqueNickname = UniqueNickname;
            this.Zipcode = Zipcode;
            this.Aim = Aim;
            this.Signature = Signature;
            this.Pid = Pid;
            this.Longnitude = Longnitude;
            this.Lattitude = Lattitude;
            this.Location = Location;
        }
    }
}
