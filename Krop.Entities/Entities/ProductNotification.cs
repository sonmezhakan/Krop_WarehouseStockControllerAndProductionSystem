using Krop.Entities.Abstracts;

namespace Krop.Entities.Entities
{
    public class ProductNotification:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid BranchId { get; set; }
        public Guid SenderAppUserId { get; set; }
        public Guid SentAppUserId { get; set; }
        public string Description { get; set; }
        public DateTime SenderNotificationDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual AppUser SenderAppUser { get; set; }
        public virtual AppUser SentAppUser { get; set; }
    }
}
