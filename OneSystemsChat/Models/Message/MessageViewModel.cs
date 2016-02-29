using System;

namespace OneSystemsChat.Models.Message
{
    /// <summary>
    /// Use this model to display the message.
    /// </summary>
    public class MessageViewModel
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        public int? RecipientId { get; set; }
    }
}