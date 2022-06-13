﻿using BussinessLayer.Interfaces;
using DataBaseLayer.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        FundooContext fundooContext;
        INoteBL noteBL;
       
        public NoteController(FundooContext fundooContext, INoteBL noteBL)
        {
            this.fundooContext = fundooContext;
            this.noteBL = noteBL;
           
        }
        [Authorize]
        [HttpPost("AddNote")]
        public async Task<ActionResult> AddNote(NotePostModel notePostModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                await this.noteBL.AddNote(userId, notePostModel);
                return this.Ok(new { success = true, message = $"Note Added Successful" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize]
        [HttpPut("ChangeColour/{NoteId}/{Colour}")]
        public async Task<ActionResult> ChangeColour(int NoteId, string Colour)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.ChangeColour(NoteId, UserId, Colour);
                return this.Ok(new { success = true, message = "Changed Colour Successfully" });

            }
            catch (Exception)
            {

                throw;
            }

        }
        [Authorize]
        [HttpPut("UpdateNote/{NoteId}")]
        public async Task<ActionResult> UpdateNote(int NoteId, UpdateModel updateModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.UpdateNote(NoteId, userId, updateModel);
                return this.Ok(new { success = true, message = "Update Successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpGet("GetParticularNote/{NoteId}")]
        public async Task<ActionResult> GetNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("UserId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                Note note = await this.noteBL.GetNote(UserId, NoteId);
                return this.Ok(new { success = true, message = "Required note is:", data = note });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Authorize]
        [HttpPut("PinNote/{NoteId}")]
        public async Task<ActionResult> PinNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.PinNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Pinned Successfully" });
            }


            catch (Exception)
            {

                throw;
            }


        }
        [Authorize]
        [HttpPut("ArchiveNote/{NoteId}")]
        public async Task<ActionResult> ArchiveNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.ArchiveNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Archived Successfully" });
            }


            catch (Exception)
            {

                throw;
            }
        }
  

       
        [Authorize]
        [HttpPut("TrashNote/{NoteId}")]
        public async Task<ActionResult> TrashNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.TrashNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note trashed Successfully" });
            }


            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPut("ReminderNote/{NoteId}")]
        public async Task<ActionResult> ReminderNote(int NoteId, DateTimeModel dateTimeModel)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int userId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == userId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Note Does not Exist " });
                }
                await this.noteBL.Reminder(NoteId, userId, dateTimeModel);
                return this.Ok(new { success = true, message = "Reminder set Successfully" });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("Delete/{NoteId}")]
        public async Task<ActionResult> RemoveNote(int NoteId)
        {
            try
            {
                var userid = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userID", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userid.Value);
                var note = fundooContext.Note.FirstOrDefault(e => e.UserId == UserId && e.NoteId == NoteId);
                if (note == null)
                {
                    return this.BadRequest(new { success = false, message = "Deletion Failed" });
                }
                await this.noteBL.RemoveNote(NoteId, UserId);
                return this.Ok(new { success = true, message = "Note Deleted Successfully" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

