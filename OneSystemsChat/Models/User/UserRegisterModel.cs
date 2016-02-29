using System.ComponentModel.DataAnnotations;

namespace OneSystemsChat.Models.User
{
    /// <summary>
    /// Use this model for the user's registration.
    /// </summary>
    public sealed class UserRegisterModel
    {
        [Required]
        [StringLength(128)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(256)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [StringLength(256)]
        public string ConfirmPassword { get; set; }
    }
}