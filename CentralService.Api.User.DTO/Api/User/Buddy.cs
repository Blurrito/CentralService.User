using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Api.User
{
    public struct Buddy
    {
        public int BuddyId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public int Status { get; set; }
        public long Date { get; set; }

        public Buddy(int BuddyId, int SenderId, int RecipientId, int Status, long Date)
        {
            this.BuddyId = BuddyId;
            this.SenderId = SenderId;
            this.RecipientId = RecipientId;
            this.Status = Status;
            this.Date = Date;
        }
    }
}
