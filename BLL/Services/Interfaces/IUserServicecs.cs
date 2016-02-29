using BLL.DTO;

namespace BLL.Services.Interfaces
{
    /// <summary>
    /// Represents an interface for the buisiness logic for the user's functionality
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Adds user to database
        /// </summary>
        /// <param name="user">User DTO</param>
        /// <returns>Added user DTO</returns>
        UserDto AddUser(UserDto user);

        /// <summary>
        /// Gets user from DB by login and password
        /// </summary>
        /// <param name="login">User's login</param>
        /// <param name="password">User's password</param>
        /// <returns>User, if user was found, NULL another way.</returns>
        UserDto GetUser(string login, string password);
    }
}
