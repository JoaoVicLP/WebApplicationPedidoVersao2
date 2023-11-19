using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class GarcomController : ControllerBase
{
    private PedidoDbContext _context;
    public GarcomController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Garcom>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Garcom is null) return NotFound();
        return await _context.Garcom.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Garcom>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Garcom is null) return NotFound();
        var garcomvar = await _context.Garcom.FindAsync(id);
        if (garcomvar is null) return NotFound();
        return garcomvar;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Garcom garcom)
    {
        if (_context is null) return NotFound();
        if (_context.Garcom is null) return NotFound();
        await _context.AddAsync(garcom);
        await _context.SaveChangesAsync();
        return Created("", garcom);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Garcom garcom)
    {
        if (_context is null) return NotFound();
        if (_context.Garcom is null) return NotFound();
        var garcomvar = await _context.Garcom.FindAsync(garcom.Id);
        if (garcomvar is null) return NotFound();
        _context.Remove(garcomvar);
        await _context.AddAsync(garcom);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Garcom is null) return NotFound();
        var garcomvar = await _context.Garcom.FindAsync(id);
        if (garcomvar is null) return NotFound();
        _context.Garcom.Remove(garcomvar);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
