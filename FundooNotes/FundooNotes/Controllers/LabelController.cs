﻿using BussinessLayer.Interfaces;
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
        
    }
}