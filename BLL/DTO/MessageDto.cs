using System;

namespace BLL.DTO
{
    /// <summary>
    /// Message DTO for the message entity
    /// </summary>
    public class MessageDto
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int? RecipientId { get; set; }
        public int UserId { get; set; }

        public virtual UserDto User { get; set; }
        public virtual UserDto Recipient { get; set; }
    }
}
