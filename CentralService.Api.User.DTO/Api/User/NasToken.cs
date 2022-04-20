using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Api.User
{
    public struct NasToken
    {
        public string Address { get; set; }
        public string Token { get; set; }
        public string Challenge { get; set; }
        public int DeviceProfileId { get; set; }
        public int GameProfileId { get; set; }
        public string GameCode { get; set; }
        public string RegionalGameCode { get; set; }
        public string UniqueNickname { get; set; }
        public DateTime ValidUntil { get; set; }

        public NasToken(string Address, string Token, string Challenge, int DeviceProfileId, int GameProfileId, string GameCode, string RegionalGameCode, string UniqueNickname)
        {
            this.Address = Address;
            this.Token = Token;
            this.Challenge = Challenge;
            this.DeviceProfileId = DeviceProfileId;
            this.GameProfileId = GameProfileId;
            this.GameCode = GameCode;
            this.RegionalGameCode = RegionalGameCode;
            this.UniqueNickname = UniqueNickname;
            ValidUntil = DateTime.Now.AddMinutes(5);
        }

        public NasToken(string Token, string Challenge, int DeviceProfileId)
        {
            this.Token = Token;
            this.Challenge = Challenge;
            this.DeviceProfileId = DeviceProfileId;

            Address = null;
            GameProfileId = 0;
            GameCode = null;
            RegionalGameCode = null;
            UniqueNickname = null;
            ValidUntil = DateTime.Now.AddMinutes(5);
        }
    }
}
