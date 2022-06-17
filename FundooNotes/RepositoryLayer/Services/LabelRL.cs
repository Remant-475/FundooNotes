using DataBaseLayer.Label;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        FundooContext fundooContext;
        IConfiguration configuration;
        public LabelRL(FundooContext fundooContext, IConfiguration configuration)
        {
            this.fundooContext = fundooContext;
            this.configuration = configuration;
        }
        public async Task AddLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                var note = fundooContext.Note.FirstOrDefault(u => u.NoteId == NoteId && u.UserId == UserId);
                if (note!= null)
                {
                    Label label = new Label();
                    label.UserId = UserId;
                    label.NoteId = NoteId;
                    label.LabelName = LabelName;
                    fundooContext.Label.Add(label);
                    await fundooContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}

