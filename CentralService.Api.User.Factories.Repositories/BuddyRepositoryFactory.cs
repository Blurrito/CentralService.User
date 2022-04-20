using CentralService.Api.User.DataAccess.Repositories;
using CentralService.Api.User.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Factories.Repositories
{
    public static class BuddyRepositoryFactory
    {
        public static IBuddyRepository GetRepository() => new BuddyRepository();
    }
}
