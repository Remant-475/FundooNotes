using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class NoteResponse
    {
        public int UserId { get; set; }
        public int NoteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public DateTime RegisterDate { get; set; }
        
    }
}
