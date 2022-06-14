using BussinessLayer.Interfaces;
using DataBaseLayer.Collaborator;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class CollabBL : ICollabBL
    {
        ICollabRL collabRL;
        public CollabBL(ICollabRL collabRL)
        {
            this.collabRL = collabRL;
        }
        public async Task AddCollab(int UserId, int NoteId, CollabValidation validation)
        {
            try
            {
                await this.collabRL.AddCollab(UserId, NoteId,validation );
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task RemoveCollab(int UserId, int NoteId)
        {
            try
            {
                await this.collabRL.RemoveCollab(NoteId, UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
