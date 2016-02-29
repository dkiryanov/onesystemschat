using System.ComponentModel.DataAnnotations;

namespace OneSystemsChat.Models.Message
{
    /// <summary>
    /// Use this model to get the messages for the private conversation between two users.
    /// </summary>
    public sealed class PrivateMessageModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RecipientId { get; set; }
    }
}