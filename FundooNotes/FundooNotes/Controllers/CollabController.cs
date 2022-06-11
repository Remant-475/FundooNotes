using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        FundooContext fundooContext;
        ICollabBL collabBL;
        public CollabController(FundooContext fundooContext, ICollabBL collabBL)
        {
            this.fundooContext = fundooContext;
            this.collabBL = collabBL;
        }
        [Authorize]
        [HttpPost("AddCollaborator")]
        public async Task<ActionResult> AddNote(int NoteId, string CollabEmail)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.collabBL.AddCollab(userId, NoteId, CollabEmail);
                return this.Ok(new { success = true, message = $"Collaborator Added Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpDelete("DeleteCollaborator/{NoteId}")]
        public async Task<ActionResult> RemoveCollab(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserID", StringComparison.InvariantCultureIgnoreCase));
                int UserID = Int32.Parse(userid.Value);
                var note = fundooContext.Collaborator.FirstOrDefault(x => x.UserId == UserID && x.NoteId == NoteId);
                if (note == null)
                    return this.BadRequest(new { success = false, message = "Sorry! This note does not exist." });
                await this.collabBL.RemoveCollab(UserID, NoteId);
                return this.Ok(new { success = true, message = "Collab Removed Successfully" });
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
