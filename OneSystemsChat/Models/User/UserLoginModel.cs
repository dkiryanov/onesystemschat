using System.ComponentModel.DataAnnotations;

namespace OneSystemsChat.Models.User
{
    /// <summary>
    /// Use this model to log the user in.
    /// </summary>
    public sealed class UserLoginModel
    {
        [Required]
        [StringLength(128)]
        public string Login { get; set; }

        [Required]
        [StringLength(256)]
        public string Password { get; set; }
    }
}