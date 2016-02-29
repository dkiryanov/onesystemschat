using System.Collections.Generic;

namespace BLL.DTO
{
    /// <summary>
    /// User DTO for the user entity
    /// </summary>
    public class UserDto
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MessageDto> Messages { get; set; }
        public virtual ICollection<MessageDto> IncomingMessages { get; set; }
    }
}
