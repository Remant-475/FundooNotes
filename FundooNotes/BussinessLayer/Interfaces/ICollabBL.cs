using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ICollabBL
    {
        Task AddCollab(int UserId, int NoteId, string CollabEmail);
        Task RemoveCollab(int UserId, int NoteId);

    }
}
