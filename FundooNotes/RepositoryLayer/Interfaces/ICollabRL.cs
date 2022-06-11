using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICollabRL
    {
        Task AddCollab(int UserId, int NoteId, string CollabEmail);
        //Task<List<Collaborator>> GetCollab(int UserId);
        Task RemoveCollab(int UserId, int NoteId);
    }
}
