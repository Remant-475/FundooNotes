using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public  class Label
    {
        [Required]
        [ForeignKey("Note")]
        public int NoteId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string LabelName { get; set; }
    }
}
