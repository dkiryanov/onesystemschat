using DAL.Entities;

namespace DAL.Repositories.Implementations
{
    public class MessageRepository : CommonRepository<Message>
    {
        /// <summary>
        /// A repository for the Message entity
        /// </summary>
        /// <param name="context"></param>
        public MessageRepository(ChatEDMContainer context) : base(context)
        {
        }
    }
}
