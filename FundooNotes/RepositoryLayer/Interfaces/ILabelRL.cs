using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public  interface ILabelRL
    {
        Task AddLabel(int UserId, int NoteId, string LabelName);
        Task RemoveLabel(int UserId, int NoteId);

    }
}
