using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Api.User.DTO.Database
{
    public class Buddy
    {
        [Key]
        public int BuddyId { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int RecipientId { get; set; }
        // 0 => Sent, 1 => Accepted, 2 => Completed
        [Required]
        public int Status { get; set; }
        [Required]
        public long Date { get; set; }

        public GameProfile Sender { get; set; }
        public GameProfile Recipient { get; set; }

        public Buddy() { }

        public Buddy(Api.User.Buddy Buddy)
        {
            BuddyId = Buddy.BuddyId;
            SenderId = Buddy.SenderId;
            RecipientId = Buddy.RecipientId;
            Status = Buddy.Status;
            Date = Buddy.Date;
        }

        public Api.User.Buddy ToBuddyDto() => new Api.User.Buddy(BuddyId, SenderId, RecipientId, Status, Date);
    }
}
