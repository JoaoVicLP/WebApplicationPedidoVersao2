using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class DescontoController : ControllerBase
{
    private PedidoDbContext _context;
    public DescontoController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Desconto>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Desconto is null) return NotFound();
        return await _context.Desconto.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Desconto>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Desconto is null) return NotFound();
        var descontovar = await _context.Desconto.FindAsync(id);
        if (descontovar is null) return NotFound();
        return descontovar;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Desconto desconto)
    {
        if (_context is null) return NotFound();
        if (_context.Desconto is null) return NotFound();
        await _context.AddAsync(desconto);
        await _context.SaveChangesAsync();
        return Created("", desconto);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Desconto desconto)
    {
        if (_context is null) return NotFound();
        if (_context.Desconto is null) return NotFound();
        var descontovar = await _context.Desconto.FindAsync(desconto.Id);
        if (descontovar is null) return NotFound();
        _context.Remove(descontovar);
        await _context.AddAsync(desconto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Desconto is null) return NotFound();
        var descontovar = await _context.Desconto.FindAsync(id);
        if (descontovar is null) return NotFound();
        _context.Desconto.Remove(descontovar);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
