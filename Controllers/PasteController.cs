using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Colle.Models;

namespace Colle.Controllers;

[Route("[controller]")]
[ApiController]
public class PasteController : ControllerBase
{
    private readonly ColleContext _context;

    public PasteController(ColleContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Paste>>> Index()
    {
        return await _context.Pastes.OrderBy(paste => paste.Id).ToListAsync();
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
        using var hasher = MD5.Create();
        paste.Checksum = Convert.ToHexString(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(paste.Contents)));
        var existing = await _context.Pastes.Where(other => other.Checksum == paste.Checksum).FirstOrDefaultAsync();
        if (existing is not null) return new OkObjectResult(existing);
        await _context.AddAsync(paste);
        await _context.SaveChangesAsync();
        return new CreatedResult(nameof(Create), paste);
    }
}
