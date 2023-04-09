using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Colle.Models;

namespace Colle.Controllers;

[Route("[controller]")]
[ApiController]
public class PasteController : ControllerBase
{
    private readonly PasteContext _context;

    public PasteController(PasteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Paste>>> Index()
    {
        return await _context.Pastes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paste>> Get(string id)
    {
        var paste = await _context.Pastes.FindAsync(id);
        if (paste == null) return NotFound();
        return paste;
    }

    [HttpPost]
    public async Task<ActionResult<Paste>> Create([Bind("Contents")] Paste paste)
    {
        if (ModelState.IsValid)
        {
            using var hasher = MD5.Create();
            await _context.AddAsync(paste);
            paste.Checksum = Convert.ToHexString(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(paste.Contents)));
            await _context.SaveChangesAsync();
            return paste;
        }
        else
        {
            return BadRequest();
        }
    }
}
