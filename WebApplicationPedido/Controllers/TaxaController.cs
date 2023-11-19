using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxaController : ControllerBase
{
    private PedidoDbContext _context;
    public TaxaController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Taxa>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Taxa is null) return NotFound();
        return await _context.Taxa.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Taxa>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Taxa is null) return NotFound();
        var taxavar = await _context.Taxa.FindAsync(id);
        if (taxavar is null) return NotFound();
        return taxavar;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Taxa taxa)
    {
        if (_context is null) return NotFound();
        if (_context.Taxa is null) return NotFound();
        await _context.AddAsync(taxa);
        await _context.SaveChangesAsync();
        return Created("", taxa);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Taxa taxa)
    {
        if (_context is null) return NotFound();
        if (_context.Taxa is null) return NotFound();
        var taxavar = await _context.Taxa.FindAsync(taxa.Id);
        if (taxavar is null) return NotFound();
        _context.Remove(taxavar);
        await _context.AddAsync(taxa);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Taxa is null) return NotFound();
        var taxavar = await _context.Taxa.FindAsync(id);
        if (taxavar is null) return NotFound();
        _context.Remove(taxavar);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
