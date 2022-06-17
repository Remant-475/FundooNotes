using BussinessLayer.Interfaces;
using DataBaseLayer.Label;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        FundooContext fundooContext;
        ILabelBL labelBL;

        public LabelController(FundooContext fundooContext, ILabelBL labelBL)
        {
            this.fundooContext = fundooContext;
            this.labelBL = labelBL;

        }
        [Authorize]
        [HttpPost("AddLabel/{NoteId}/{LabelName}")]
        public async Task<ActionResult> AddLabel(int NoteId,string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note== null)
                {
                    return this.BadRequest(new { success = false, message = "Note does not exist" });
                }
                await this.labelBL.AddLabel(userId, NoteId,LabelName);
                return this.Ok(new { success = true, message = $"Label Added Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteLabel/{NoteId}")]
        public async Task<ActionResult> RemoveLabel(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist" });
                }
                var label = fundooContext.Label.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (label == null)
                {
                    return this.BadRequest(new { success = false, message = "Label Not Added" });
                }
                await this.labelBL.RemoveLabel(NoteId, UserId);
                return this.Ok(new { success = true, message = "Label Deleted Successfully" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateLabel/{NoteId}")]
        public async Task<ActionResult> UpdateNote(int NoteId, string LabelName)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                var label = fundooContext.Label.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                if (label == null)
                {
                    return this.BadRequest(new { success = false, message = " label not added " });
                }
                await this.labelBL.UpdateLabel(NoteId, userId, LabelName);
                return this.Ok(new { success = true, message = "Update Successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("GetParticularLabel/{NoteId}")]
        public async Task<ActionResult> GetLabel(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                var label1 = fundooContext.Label.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (label1 == null)
                {
                    return this.BadRequest(new { success = false, message = "Label Not Added" });
                }
                Label label = await this.labelBL.GetLabel(UserId, NoteId);
                return this.Ok(new { success = true, message = "Required Label is:", data = label });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpGet("GetallLabel")]
        public async Task<ActionResult> GetallLabel()
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                List<Label> label = await this.labelBL.GetallLabel(UserId);
                return this.Ok(new { success = true, message = " List of all Labels :", data = label });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
