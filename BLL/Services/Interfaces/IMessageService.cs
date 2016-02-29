using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    /// <summary>
    /// Represents an interface for the buisiness logic for the message's functionality
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Gets all public messages (the messages was not addressed to another user)
        /// </summary>
        /// <returns>A collection of the public messsages</returns>
        IEnumerable<MessageDto> GetAllPublicMessages();

        /// <summary>
        /// Adds new message.
        /// </summary>
        /// <param name="message">Message DTO.</param>
        /// <returns>Message DTO according to the entity that has been added.</returns>
        MessageDto AddMessage(MessageDto message);
        IEnumerable<MessageDto> GetMessagesForPrivateConversation(int userId, int recipientId);
    }
}
