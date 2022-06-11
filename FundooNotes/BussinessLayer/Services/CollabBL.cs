using BussinessLayer.Interfaces;
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
        public async Task AddCollab(int UserId, int NoteId, string CollabEmail)
        {
            try
            {
                await this.collabRL.AddCollab(UserId, NoteId, CollabEmail);
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
