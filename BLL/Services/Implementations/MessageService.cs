using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UoW;

namespace BLL.Services.Implementations
{
    /// <summary>
    /// Represents an implementation of the business logic for the Message's functionality.
    /// </summary>
    public sealed class MessageService : IMessageService
    {
        public IEnumerable<MessageDto> GetAllPublicMessages()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var tmp = uow.Messages.GetAll().Where(m => m.RecipientId.HasValue == false).ToList();
                return tmp.Select(Mapper.Map<MessageDto>).ToList();
            }
        }

        public MessageDto AddMessage(MessageDto message)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Message messageToAdd = Mapper.Map<Message>(message);
                
                User user = uow.Users.Get(message.UserId);

                if (message.RecipientId != null)
                {
                    User recipient = uow.Users.Get(message.RecipientId);
                    
                    if (recipient != null)
                    {
                        messageToAdd.Recipient = recipient;
                    }
                }

                user.Messages.Add(messageToAdd);

                uow.SaveChanges();

                return Mapper.Map<MessageDto>(messageToAdd);
            }
        }

        public IEnumerable<MessageDto> GetMessagesForPrivateConversation(int userId, int recipientId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Messages.GetAll()
                    .Where(m => (m.RecipientId == recipientId || m.RecipientId == userId) && (m.UserId == userId || m.UserId == recipientId))
                    .Select(Mapper.Map<MessageDto>)
                    .OrderBy(m => m.Date)
                    .ToList();
            }
        }
    }
}
