using CentralService.Api.User.DTO.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.Interfaces.Repositories
{
    public interface IBuddyRepository : IRepository<Buddy>
    {
        Task AddBuddy(Buddy Request);
        Task<List<Buddy>> FindBuddies(Expression<Func<Buddy, bool>> Predicate);
        Task<List<Buddy>> GetIncomingRequests(int RecipientId);
        Task<List<Buddy>> GetBuddyList(int SenderId);
        Task<Buddy> GetBuddyRequest(int BuddyId);
        Task<Buddy> GetBuddyRequest(int SenderId, int RecipientId);
        void RemoveBuddy(Buddy Profile);
        void UpdateBuddy(Buddy Profile);
    }
}
