using System.Collections.Generic;
using OneSystemsChat.Models.Message;

namespace OneSystemsChat.Models.User
{
    /// <summary>
    /// Represents a view model for user.
    /// </summary>
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }

        public ICollection<MessageViewModel> Messages { get; set; }
        public ICollection<MessageViewModel> IncomingMessages { get; set; }
    }
}