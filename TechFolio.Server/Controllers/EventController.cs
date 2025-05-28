using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;
using UsersApp.Data;
using UsersApp.DTOs;
using UsersApp.Models;
using System.IO;



namespace UsersApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll()
        {
            return await _context.Events.Select(e => new EventDto
            {
                Id = e.Id,
                Name = e.Name,
                Date = e.Date,
                FeedbackFormUrl = e.FeedbackFormUrl,
                IsPresent = e.IsPresent
            }).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(EventUploadRequest request)
        {
            var newEvent = new Event
            {
                Name = request.Name,
                Date = request.Date,
                FeedbackFormUrl = request.FeedbackFormUrl,
                IsPresent = false
            };
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            // 
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(request.FeedbackFormUrl, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            using var qrBitmap = qrCode.GetGraphic(20);
            using var stream = new MemoryStream();
            qrBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            var base64 = Convert.ToBase64String(stream.ToArray());

            return Ok($"data:image/png;base64,{base64}");
        }

        [HttpPut("{id}/attendance")]
        public async Task<IActionResult> MarkAttendance(int id, [FromBody] bool isPresent)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            ev.IsPresent = isPresent;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
