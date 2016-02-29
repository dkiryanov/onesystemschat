using System.Web;
using OneSystemsChat.Models.User;

namespace OneSystemsChat.Helpers
{
    public static class SessionHelper
    {
        public static UserViewModel CurrentUser()
        {
            return HttpContext.Current.Session["User"] as UserViewModel;
        }
    }
}