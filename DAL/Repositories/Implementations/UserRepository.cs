using DAL.Entities;

namespace DAL.Repositories.Implementations
{
    public class UserRepository : CommonRepository<User>
    {
        /// <summary>
        /// A repository for the User entity
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ChatEDMContainer context) : base(context)
        {
        }
    }
}
