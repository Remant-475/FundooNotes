using DataBaseLayer.Collaborator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CollabRL : ICollabRL
    {
        FundooContext fundoocontext;
        IConfiguration configuration;
        public CollabRL(FundooContext fundooContext, IConfiguration configuration)
        { 
            this.fundoocontext = fundooContext;
            this.configuration = configuration;
        }
        public async Task AddCollab(int UserId, int NoteId, CollabValidation validation)
        {
            try
            {
               
                Collaborator collabrator = new Collaborator
                {
                    UserId = UserId,
                    NoteId = NoteId
                };
                collabrator.CollabEmail = validation.CollabEmail;
                fundoocontext.Add(collabrator);
                await fundoocontext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
}
