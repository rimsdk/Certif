﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_Certif.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestCertifController : ControllerBase
    {
        private readonly MyContext _context;

        public RequestCertifController(MyContext context)
        {
            _context = context;
        }

        // POST: api/RequestCertif
        [HttpPost]
        public async Task<IActionResult> PostRequestCertif([FromBody] AddRequest_certifVM dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var requestCertif = new Request_certif
            {
                requestDate = dto.RequestDate,
                status = "Pending",
                decisionReason = string.Empty,
                required = dto.Required,
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
               AllCertifId = dto.AllCertifId,

    };

            _context.Request_Certifs.Add(requestCertif);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return CreatedAtAction(nameof(GetRequestCertif), new { id = requestCertif.id }, requestCertif);
        }

        // GET: api/RequestCertif/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestCertif(int id)
        {
            var requestCertif = await _context.Request_Certifs.FindAsync(id);

            if (requestCertif == null)
            {
                return NotFound();
            }

            return Ok(requestCertif);
        }

        // GET: api/RequestCertif
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddRequest_certifVM>>> GetRequestCertifs()
        {
            var requestCertifs = await _context.Request_Certifs
                .Select(rc => new AddRequest_certifVM
                {
                    Id = rc.id,
                    RequestDate = rc.requestDate,
                    Status = rc.status,
                    DecisionReason = rc.decisionReason,
                    Required = rc.required,
                    SenderId = rc.SenderId,
                    ReceiverId = rc.ReceiverId,
                    AllCertifId = rc.AllCertifId,
                })
                .ToListAsync();

            return Ok(requestCertifs);
        }

        // GET: api/RequestCertif/{id}/sent-requests
        [HttpGet("{id}/sent-requests")]
        public async Task<ActionResult<IEnumerable<AddRequest_certifVM>>> GetSentRequests(int id)
        {
            var sentRequests = await _context.Users
                .Where(u => u.id == id)
                .SelectMany(u => u.SentRequests)
                .Select(r => new AddRequest_certifVM
                {
                    Id = r.id,
                    RequestDate = r.requestDate,
                    Status = r.status,
                    DecisionReason = r.decisionReason,
                    Required = r.required,
                    SenderId = r.SenderId,
                    ReceiverId = r.ReceiverId,
                    AllCertifId = r.AllCertifId,
                    AllCertifName = r.AllCertif.certifName,
                })
                .ToListAsync();

            if (!sentRequests.Any())
            {
                return NotFound();
            }

            return Ok(sentRequests);
        }

        // GET: api/RequestCertif/{id}/received-requests
        [HttpGet("{id}/received-requests")]
        public async Task<ActionResult<IEnumerable<AddRequest_certifVM>>> GetReceivedRequests(int id)
        {
            var receivedRequests = await _context.Users
                .Where(u => u.id == id)
                .SelectMany(u => u.ReceivedRequests)
                .Select(r => new AddRequest_certifVM
                {
                    Id = r.id,
                    RequestDate = r.requestDate,
                    Status = r.status,
                    DecisionReason = r.decisionReason,
                    Required = r.required,
                    SenderId = r.SenderId,
                    ReceiverId = r.ReceiverId,
                    AllCertifId = r.AllCertifId,
                })
                .ToListAsync();

            if (!receivedRequests.Any())
            {
                return NotFound();
            }

            return Ok(receivedRequests);
        }

        // PATCH: api/RequestCertif/{id}/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateRequestStatusDto updateRequestStatusDto)
        {
            if (updateRequestStatusDto == null || string.IsNullOrEmpty(updateRequestStatusDto.Status))
            {
                return BadRequest("Invalid status value.");
            }

            var request = await _context.Request_Certifs.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.status = updateRequestStatusDto.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Request_certifExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool Request_certifExists(int id)
        {
            return _context.Request_Certifs.Any(e => e.id == id);
        }
        // GET: api/RequestCertif/{id}/received-certifs
        [HttpGet("{id}/received-certifs")]
        public async Task<ActionResult<IEnumerable<AddRequest_certifVM>>> GetReceivedCertif(int id)
        {
            var receivedCertifs = await _context.Request_Certifs
                .Where(rc => rc.ReceiverId == id)
                .Select(rc => new AddRequest_certifVM
                {
                    Id = rc.id,
                    RequestDate = rc.requestDate,
                    Status = rc.status,
                    DecisionReason = rc.decisionReason,
                    Required = rc.required,
                    SenderId = rc.SenderId,
                    ReceiverId = rc.ReceiverId,
                    AllCertifId = rc.AllCertifId,
                    AllCertifName = rc.AllCertif.certifName,
                    SenderName = rc.Sender.username,
                })
                .ToListAsync();

            if (!receivedCertifs.Any())
            {
                return NotFound();
            }

            return Ok(receivedCertifs);
        }
        [HttpGet("senderProfiles")]
        public async Task<IActionResult> GetSenderProfiles([FromQuery] List<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return BadRequest("No IDs provided.");
            }

            var profiles = await _context.Users
                .Where(user => ids.Contains(user.id))
                .Select(user => new
                {
                    user.id,
                    user.username,
                    user.email,
                    user.role,
                    user.DepartementId,
                    user.Request_certifId,
                    user.ProfilePictureUrl
                })
                .ToListAsync();

            return Ok(profiles);
        }

    }
}
