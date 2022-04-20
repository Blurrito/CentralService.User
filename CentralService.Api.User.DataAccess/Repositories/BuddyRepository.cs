using CentralService.Api.User.DTO.Database;
using CentralService.Api.User.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DataAccess.Repositories
{
    public class BuddyRepository : Repository<Buddy>, IBuddyRepository
    {
        public BuddyRepository() : base() { }

        public async Task AddBuddy(Buddy Request) => await Add(Request);

        public async Task<List<Buddy>> FindBuddies(Expression<Func<Buddy, bool>> Predicate) => await Find(Predicate);

        public async Task<List<Buddy>> GetIncomingRequests(int RecipientId) => await Find(x => x.Status == 0 && x.RecipientId == RecipientId);

        public async Task<List<Buddy>> GetBuddyList(int SenderId) => await Find(x => x.SenderId == SenderId);

        public async Task<Buddy> GetBuddyRequest(int BuddyId) => await Get(x => x.BuddyId == BuddyId);

        public async Task<Buddy> GetBuddyRequest(int SenderId, int RecipientId) => await Get(x => x.SenderId == SenderId && x.RecipientId == RecipientId);

        public void RemoveBuddy(Buddy Profile) => Remove(Profile);

        public void UpdateBuddy(Buddy Profile) => Update(Profile);
    }
}
