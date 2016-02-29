using System;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UoW;

namespace BLL.Services.Implementations
{
    /// <summary>
    /// Represents an implementation of the business logic for the User's functionality.
    /// </summary>
    public sealed class UserService : IUserService
    {
        public UserDto AddUser(UserDto user)
        {
            if (user == null) return null;

            using (UnitOfWork uow = new UnitOfWork())
            {
                User addedUser = uow.Users.Create(Mapper.Map<User>(user));

                uow.SaveChanges();

                return Mapper.Map<UserDto>(addedUser);
            }
        }

        public UserDto GetUser(string login, string password)
        {
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password)) return null;

            using (UnitOfWork uow = new UnitOfWork())
            {
                User user = uow.Users.Find(u => u.Login == login).FirstOrDefault();

                if (user == null) return null;

                return user.Password.Equals(password) ? Mapper.Map<UserDto>(user) : null;
            }
        }
    }
}
