using DataBaseLayer.Users;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;
        public UserRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundoocontext = fundooContext;
            this.configuration = configuration;
        }

        public void AddUser(UserPostModel userPostModel)
        {
            try
            {
                User user = new User();
                user.FirstName = userPostModel.FirstName;
                user.LastName = userPostModel.LastName;
                user.Email = userPostModel.Email;
                user.Password = userPostModel.Password;
                user.Address = userPostModel.Address;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                fundoocontext.Add(user);
                fundoocontext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
