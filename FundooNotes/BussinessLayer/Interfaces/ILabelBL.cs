using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ILabelBL
    {
        Task AddLabel(int UserId, int NoteId, string LabelName);
        Task RemoveLabel(int UserId, int NoteId);
        Task UpdateLabel(int UserId, int NoteId, string LabelName);
        Task<Label> GetLabel(int UserId, int NoteId);
        Task<List<Label>> GetallLabel(int UserId);
    }
}
