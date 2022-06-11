using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Collaborator
    {
        public int UserId { get; set; }
        public  User user { get; set; }
        public int NoteId { get; set; }
        public  Note note { get; set; }
        public string CollabEmail { get; set; }
    }
}
