using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using OneSystemsChat.Helpers;
using OneSystemsChat.Models;
using OneSystemsChat.Models.Chat;
using OneSystemsChat.Models.Message;
using OneSystemsChat.Models.User;
using OneSystemsChat.Resources;

namespace OneSystemsChat.Controllers
{
    /// <summary>
    /// Controller for the chat's functionality
    /// </summary>
    public class ChatController : Controller
    {
        private readonly IMessageService _messageService;

        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Index()
        {
            UserViewModel currentUser = SessionHelper.CurrentUser();

            if (currentUser == null)
            {
                return Redirect("/User/Login/");
            }

            ChatViewModel chatModel = new ChatViewModel
            {
                CurrentUserId = currentUser.UserId,
                CurrentUserLogin = currentUser.Login,
                Messages = _messageService.GetAllPublicMessages().Select(Mapper.Map<MessageViewModel>)
            };

            return View(chatModel);
        }

        [HttpPost]
        public JsonResult GetPublicMessages()
        {
            return Json(_messageService.GetAllPublicMessages().Select(Mapper.Map<MessageViewModel>));
        }

        [HttpPost]
        public JsonResult AddMessage(MessageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                MessageDto dto = Mapper.Map<MessageDto>(model);

                UserViewModel currentUser = SessionHelper.CurrentUser();

                if (currentUser == null) return null;

                dto.UserId = currentUser.UserId;
                dto.Date = DateTime.UtcNow;

                MessageDto addedMessage = _messageService.AddMessage(dto);

                return Json(Mapper.Map<MessageViewModel>(addedMessage)); 
            }

            return Json(new ResponseModel { Message = Common.ModelIsNotValid, IsSuccess = false });
        }

        [HttpPost]
        public JsonResult GetMessagesForPrivateConversation(PrivateMessageModel model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<MessageViewModel> messages = _messageService.GetMessagesForPrivateConversation(model.UserId, model.RecipientId).Select(Mapper.Map<MessageViewModel>).ToList();
                return Json(new {Messages = messages, IsSuccess = true});
            }

            return Json(new ResponseModel {Message = Common.ModelIsNotValid, IsSuccess = false});
        }
	}
}