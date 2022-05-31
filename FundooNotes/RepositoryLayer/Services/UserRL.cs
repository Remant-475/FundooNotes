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
        
        public string LoginUser(string Email, string Password)
        {
            try
            {
                var user = fundoocontext.User.FirstOrDefault(u => u.Email == Email && u.Password == Password);
                if (user != null)
                {
                    return GenerateJWToken(Email, user.UserId);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public bool ForgetPassword(string Email)
        {
            try
            {
                var user = fundoocontext.User.FirstOrDefault(u => u.Email == Email);
                if (user == null)
                {
                    return false;
                }
                MessageQueue messageQueue = new MessageQueue();
                messageQueue.Path = @".\private$\FundooQueue";
                //ADD MESSAGE TO QUEUE
                if (MessageQueue.Exists(messageQueue.Path))
                {
                    messageQueue = new MessageQueue(messageQueue.Path);
                }
                else
                {
                    messageQueue = MessageQueue.Create(@".\Private$\FundooQueue");
                }
                Message MyMessage = new Message();
                MyMessage.Formatter = new BinaryMessageFormatter();
                MyMessage.Body = GenerateJWToken(Email, user.UserId);
                MyMessage.Label = "Forget Password Label";
                messageQueue.Send(MyMessage);
                Message msg = messageQueue.Receive();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private string GenerateJWToken(string Email, int userId)
        {
            var user = fundoocontext.User.FirstOrDefault(u => u.Email == Email);
            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("userId",userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }



    }
}
