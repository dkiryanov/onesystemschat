using System.Collections.Generic;
using OneSystemsChat.Models.Message;

namespace OneSystemsChat.Models.Chat
{
    /// <summary>
    /// Represents the view model for the chat. 
    /// Use this model to display information about the current user and messages.
    /// </summary>
    public sealed class ChatViewModel
    {
        public string CurrentUserLogin { get; set; }
        public int CurrentUserId { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; }
    }
}