using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineVote.Models.Domain
{
    [Table("tblSubscriptionNotifications")]
    public class SubscriptionNotifications
    {

        [Key]
        public int SubscriptionNotificationsKey {get;set;}

        [ForeignKey("Subscription")]
        [Column("SubscriptionId")]
        public int SubscriptionId { get; set; }

        [Column("Subscription")]
        public Subscription? Subscription { get; set; }

        [ForeignKey("Notification")]
        [Column("NotificationId")]
        public int NotificationId { get; set; }

        [Column("Notification")]
        public Notification? Notification { get; set; }
    }
}
