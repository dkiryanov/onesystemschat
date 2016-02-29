using System;
using System.Web.Mvc;
using BLL.Infrastructure;
using BLL.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OneSystemsChat.App_Start;
using OneSystemsChat.Controllers;
using OneSystemsChat.Models;
using OneSystemsChat.Models.User;
using OneSystemsChat.Resources;
using Tests.Extensions;

namespace Tests
{
    [TestClass]
    public class UserControllerTest
    {
        public UserControllerTest()
        {
            AutomapperConfig.RegisterMappings();
            AutomapperBllConfig.RegisterMappings();
        }

        [TestMethod]
        public void Login_PostAction_LoginFieldIsEmpty()
        {
            //Arrange
            Mock<IUserService> moq = new Mock<IUserService>();
            UserController controller = new UserController(moq.Object);

            //Act
            JsonResult result = controller.Login(new UserLoginModel() { Password = "123" });
            
            //Assert
            Assert.IsNotNull(result);

            ResponseModel response = new ResponseModel()
            {
                IsSuccess = (bool)result.GetPropertyValue("IsSuccess"),
                Message = (string)result.GetPropertyValue("Message")
            };

            Assert.IsTrue(response.IsSuccess == false, "ResponseModel.IsSuccess != false");
            Assert.IsTrue(response.Message == Common.LoginOrPasswordAreIncorrect, String.Concat("ResponseModel.Message != ", Common.LoginOrPasswordAreIncorrect));
        }

        [TestMethod]
        public void Login_PostAction_PasswordFieldIsEmpty()
        {
            //Arrange
            Mock<IUserService> moq = new Mock<IUserService>();
            UserController controller = new UserController(moq.Object);

            //Act
            JsonResult result = controller.Login(new UserLoginModel() { Login = "SantaClaus" });

            //Assert
            Assert.IsNotNull(result);

            ResponseModel response = new ResponseModel()
            {
                IsSuccess = (bool)result.GetPropertyValue("IsSuccess"),
                Message = (string)result.GetPropertyValue("Message")
            };

            Assert.IsTrue(response.IsSuccess == false, "ResponseModel.IsSuccess != false");
            Assert.IsTrue(response.Message == Common.LoginOrPasswordAreIncorrect, String.Concat("ResponseModel.Message != ", Common.LoginOrPasswordAreIncorrect));
        }

        [TestMethod]
        public void Login_PostAction_WrongCredentials()
        {
            //Arrange
            Mock<IUserService> moq = new Mock<IUserService>();
            UserController controller = new UserController(moq.Object);

            //Act
            JsonResult result = controller.Login(new UserLoginModel() { Login = Guid.NewGuid().ToString(), Password = "123" });

            //Assert
            Assert.IsNotNull(result);

            ResponseModel response = new ResponseModel()
            {
                IsSuccess = (bool)result.GetPropertyValue("IsSuccess"),
                Message = (string)result.GetPropertyValue("Message")
            };

            Assert.IsTrue(response.IsSuccess == false, "ResponseModel.IsSuccess != false");
            Assert.IsTrue(response.Message == Common.LoginOrPasswordAreIncorrect, String.Concat("ResponseModel.Message != ", Common.LoginOrPasswordAreIncorrect));
        }
    }
}
