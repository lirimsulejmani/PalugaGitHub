using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseLayer.Models
{
    public class Notification : BaseEntity
    {
        public NotificationTypeEnum NotificationType { get; set; }

        public Wishlist Wishlist { get; set; }

        public DateTime EntryDate { get; set; }
    }

    public enum NotificationTypeEnum
    {
        Email,
        SMS,
        Both
    }
}
