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
        if (_context.Taxa is null) return NotFound();
        return await _context.Taxa.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{tipo}")]

    public async Task<ActionResult<Taxa>> Buscar(string tipo)
    {
        if (_context.Taxa is null) return NotFound();
        var Taxa = await _context.Taxa.FindAsync(tipo);
        return Taxa;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Taxa Taxa)
    {
        await _context.AddAsync(Taxa);
        await _context.SaveChangesAsync();
        return Created("", Taxa);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Taxa Taxa)
    {
        _context.Taxa.Update(Taxa);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{taxa}")]
    public async Task<IActionResult> Excluir(string tipo)
    {
        var Taxa = await _context.Taxa.FindAsync(tipo);
        if (Taxa is null) return NotFound();
        _context.Taxa.Remove(Taxa);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
