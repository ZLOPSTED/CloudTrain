﻿using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DataAccess.Repositories;
using DataAccess.Models;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using DataAccess.Identity;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Services
{
    class UserService : IUserService
    {
        IIdentityUnitOfWork Database { get; set; }

        public UserService(IIdentityUnitOfWork uow)
        {
            Database = uow;
        }



        public async Task<OperationDetails> Create(UserDTO userDto)
        {

            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
           
            if (user == null)
            {
                user = new User { Email = userDto.Email, Name = userDto.Name, Birthday = userDto.Birthday, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                await Database.UserManager.AddToRoleAsync(user.Id, "user");
                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }



        }





        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            User user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
              
            return claim;
        }

      
        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
