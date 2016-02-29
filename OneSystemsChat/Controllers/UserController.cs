using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using OneSystemsChat.Models;
using OneSystemsChat.Models.User;
using OneSystemsChat.Resources;

namespace OneSystemsChat.Controllers
{
    /// <summary>
    /// Controller for the user's functionality
    /// </summary>
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(UserLoginModel model)
        {
            if (!ModelState.IsValid) return Json(new ResponseModel { Message = Common.ModelIsNotValid, IsSuccess = false });
            
            UserDto userDto = _userService.GetUser(model.Login, model.Password);

            if (userDto == null)
            {
                return Json(new ResponseModel { Message = Common.LoginOrPasswordAreIncorrect, IsSuccess = false });
            }
            
            Session.Add("User", Mapper.Map<UserViewModel>(userDto));
            
            return Json(new ResponseModel { IsSuccess = true });
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto addedUserDto = _userService.AddUser(Mapper.Map<UserDto>(model));

                if (addedUserDto == null) return Json(new ResponseModel { Message = Common.RegistrationFailed, IsSuccess = false });

                Session.Add("User", Mapper.Map<UserViewModel>(addedUserDto));

                return Json(new ResponseModel { Message = Common.RegistrationCompleted, IsSuccess = true });
            }
            
            return Json(new ResponseModel { Message = Common.ModelIsNotValid, IsSuccess = false });
        }

        public ActionResult LogOut()
        {
            Session["User"] = null;
            return Redirect("/User/Login/");
        }
    }
}