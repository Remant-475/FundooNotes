using DataBaseLayer.Notes;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface INoteBL
    {
        Task AddNote(int UserId, NotePostModel notePostModel);
        Task ChangeColour(int UserId, int NoteId, string Colour);
        Task UpdateNote(int UserId, int NoteId, UpdateModel updateModel);
        Task<Note> GetNote(int UserId, int NoteId);
        Task PinNote(int UserId, int NoteId);
        Task ArchiveNote(int UserId, int NoteId);
        Task Reminder(int UserId, int NoteId, DateTimeModel dateTimeModel);
        Task TrashNote(int UserId, int NoteId);

        Task RemoveNote(int UserId, int NoteId);
        Task<List<Note>> GetallNotes(int UserId);
    }
}
