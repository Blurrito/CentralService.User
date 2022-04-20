using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralService.Api.User.DTO.Database
{
    public class GameProfile
    {
        [Key]
        public int GameProfileId { get; set; }
        [Required]
        public int DeviceProfileId { get; set; }
        [Required]
        public string GameCode { get; set; }
        [Required]
        public string Gsbrcd { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string UniqueNickname { get; set; }
        public string Zipcode { get; set; }
        public string Aim { get; set; }
        [Required]
        public string Signature { get; set; }
        [Required]
        public int Pid { get; set; }
        [Required]
        public float Longnitude { get; set; }
        [Required]
        public float Lattitude { get; set; }
        [Required]
        public string Location { get; set; }

        public List<Buddy> Buddies { get; set; }
        public List<Buddy> IncomingRequests { get; set; }

        public GameProfile() { }

        public GameProfile(string Gsbrcd, string GameCode, long DeviceId, int DeviceProfileId = 0)
        {
            this.DeviceProfileId = DeviceProfileId;
            this.GameCode = GameCode;
            this.Gsbrcd = Gsbrcd;

            UniqueNickname = $"{ Base32Encode(DeviceId) }{ Gsbrcd }";
            Nickname = UniqueNickname;
            Email = $"{ UniqueNickname }@nds";
            Signature = "8f1f2eaa285bce91054a3768b3dbf141";
            Pid = 11;
            Longnitude = 0f;
            Lattitude = 0f;
            Location = string.Empty;

            FirstName = null;
            LastName = null;
            Zipcode = null;
            Aim = null;
        }

        public void Update(Api.User.GameProfile Profile)
        {
            Nickname = Profile.Nickname != null ? Profile.Nickname : Nickname;
            FirstName = Profile.FirstName != null ? Profile.FirstName : FirstName;
            LastName = Profile.LastName != null ? Profile.LastName : LastName;
            Zipcode = Profile.Zipcode != null ? Profile.Zipcode : Zipcode;
            Aim = Profile.Aim != null ? Profile.Aim : Aim;
            Longnitude = Profile.Longnitude > 0 ? Profile.Longnitude : Longnitude;
            Lattitude = Profile.Lattitude > 0 ? Profile.Lattitude : Lattitude;
            Location = Profile.Location != null ? Profile.Location : Location;
        }

        public Api.User.GameProfile ToGameProfileDTO() => new Api.User.GameProfile(GameProfileId, DeviceProfileId, GameCode, Gsbrcd, FirstName,
                    LastName, Email, Nickname, UniqueNickname, Zipcode, Aim, Signature, Pid, Longnitude, Lattitude, Location);

        /// <summary>
        /// Converts an integer to a base32 encoded string.
        /// Courtesy to dwc server emulator project (https://github.com/barronwaffles/dwc_network_server_emulator) for this!
        /// </summary>
        /// <param name="Input">The input integer.</param>
        /// <param name="Reverse">Determines whether or not the result string should be reversed before being returned (Default is true).</param>
        /// <returns>The provided integer converted to a base32 encoded string.</returns>
        private static string Base32Encode(long Input, bool Reverse = true)
        {
            string CharSet = "0123456789abcdefghijklmnopqrstuv";
            string Encoded = "";

            while (Input > 0)
            {
                Encoded += CharSet[(int)(Input & 0x1F)];
                Input >>= 5;
            }

            if (Reverse)
            {
                char[] Buffer = Encoded.ToCharArray();
                Array.Reverse(Buffer);
                Encoded = new string(Buffer);
            }
            return Encoded;
        }
    }
}
