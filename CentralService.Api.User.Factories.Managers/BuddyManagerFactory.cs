using CentralService.Api.User.Core;
using CentralService.Api.User.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Factories.Managers
{
    public static class BuddyManagerFactory
    {
        public static IBuddyManager GetManager() => new BuddyManager();
    }
}
