using BussinessLayer.Interfaces;
using DataBaseLayer.Label;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;
        }
        public async Task AddLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                await labelRL.AddLabel(UserId,NoteId,LabelName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveLabel(int UserId, int NoteId)
        {
            try
            {
                await this.labelRL.RemoveLabel(NoteId, UserId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task UpdateLabel(int UserId, int NoteId, string LabelName)
        {
            try
            {
                await this.labelRL.UpdateLabel(NoteId, UserId, LabelName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Label> GetLabel(int UserId, int NoteId)
        {
            try
            {
                return await this.labelRL.GetLabel(UserId, NoteId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Label>> GetallLabel(int UserId)
        {
            try
            {
                return await this.labelRL.GetallLabel(UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
