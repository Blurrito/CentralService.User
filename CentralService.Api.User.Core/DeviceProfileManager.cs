using CentralService.Api.User.DTO.Api.Common;
using CentralService.Api.User.DTO.Api.User;
using CentralService.Api.User.Factories.Repositories;
using CentralService.Api.User.Interfaces.Managers;
using CentralService.Api.User.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Core
{
    public class DeviceProfileManager : IDeviceProfileManager
    {
        public DeviceProfileManager() { }

        public async Task<ApiResponse?> CreateDeviceProfile(DeviceProfile Request)
        {
            DTO.Database.DeviceProfile ExistingProfile = null;
            await using (IDeviceProfileRepository Repository = DeviceProfileRepositoryFactory.GetDeviceProfileRepository())
            {
                ExistingProfile = await Repository.GetDeviceProfile(Request.DeviceId);
                if (ExistingProfile == null)
                {
                    ExistingProfile = new DTO.Database.DeviceProfile(Request);
                    await Repository.AddDeviceProfile(ExistingProfile);
                }
            }
            return new ApiResponse(true, ExistingProfile.DeviceProfileId);
        }

        public async Task<ApiResponse?> NasLogin(string Address, DeviceProfile Request)
        {
            DTO.Database.DeviceProfile ExistingProfile = null;
            GameProfile Game;
            await using (IDeviceProfileRepository Repository = DeviceProfileRepositoryFactory.GetDeviceProfileRepository())
            {
                ExistingProfile = await Repository.GetDeviceProfile(Request.DeviceId);
                if (ExistingProfile == null)
                    return new ApiResponse(false, new ApiError());

                //TODO: Add a blacklist check

                //TODO: properly hash this
                if (Request.Password != ExistingProfile.Password)
                    return new ApiResponse(false, new ApiError(119, "An error occurred while validating the pre-authentication.", true));

                if (Request.GameProfiles == null)
                    throw new ArgumentException("Device profile does not contain a game profile.", nameof(Request.GameProfiles));
                if (Request.GameProfiles.Count == 0)
                    throw new ArgumentException("Device profile does not contain a game profile.", nameof(Request.GameProfiles));
                if (Request.GameProfiles[0].Gsbrcd != null)
                    if (Request.GameProfiles[0].Gsbrcd != string.Empty)
                    {
                        using (GameProfileManager Manager = new GameProfileManager())
                            Game = await Manager.CreateGameProfile(ExistingProfile.DeviceProfileId, Request.DeviceId, Request.GameProfiles[0].Gsbrcd, Request.GameProfiles[0].GameCode);
                        return new ApiResponse(true, new NasToken(Address, GenerateToken(), GenerateChallenge(), ExistingProfile.DeviceProfileId, Game.GameProfileId, Game.Gsbrcd.Substring(0, 4), Game.GameCode, Game.UniqueNickname));
                    }
                return new ApiResponse(true, new NasToken(GenerateToken(), GenerateChallenge(), ExistingProfile.DeviceProfileId));
            }
        }

        public static string GenerateChallenge()
        {
            string ReturnString = string.Empty;
            string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random Random = new Random();
            for (int i = 0; i < 8; i++)
                ReturnString += CharSet[Random.Next(CharSet.Length)];
            return ReturnString;
        }

        private static string GenerateToken()
        {
            Random NumberGenerator = new Random();
            byte[] TokenBase = new byte[96];
            for (int i = 0; i < TokenBase.Length; i++)
                TokenBase[i] = (byte)NumberGenerator.Next(byte.MaxValue + 1);
            return $"NDS{ Convert.ToBase64String(TokenBase) }";
        }

        public void Dispose() { }
    }
}
