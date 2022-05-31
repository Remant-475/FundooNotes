using BussinessLayer.Interfaces;
using DataBaseLayer.Users;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRl;
        public UserBL(IUserRL userRL)
        {
            this.userRl = userRL;
        }
        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                this.userRl.AddUser(userPostModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string LoginUser(string Email, string Password)
        {
            try
            {
                return this.userRl.LoginUser(Email, Password);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
