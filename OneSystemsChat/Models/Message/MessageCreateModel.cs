using System.ComponentModel.DataAnnotations;

namespace OneSystemsChat.Models.Message
{
    /// <summary>
    /// Use this model to create new message.
    /// </summary>
    public class MessageCreateModel
    {
        [Required]
        public string Content { get; set; }
        public int? RecipientId { get; set; }
    }
}