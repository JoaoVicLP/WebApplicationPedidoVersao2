using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class MesaController : ControllerBase

{
    public PedidoDbContext _context;

    public MesaController(PedidoDbContext context)
    {
        _context = context;
    }
    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Mesa>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        return await _context.Mesa.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Mesa>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        var mesavar = await _context.Mesa.FindAsync(id);
        if (mesavar is null) return NotFound();
        return mesavar;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Mesa mesa)
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        await _context.AddAsync(mesa);
        await _context.SaveChangesAsync();
        return Created("", mesa);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Mesa mesa)
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        var mesavar = await _context.Mesa.FindAsync(mesa.Id);
        if (mesavar is null) return NotFound();
        _context.Remove(mesavar);
        await _context.AddAsync(mesa);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        var mesavar = await _context.Mesa.FindAsync(id);
        if (mesavar is null) return NotFound();
        _context.Remove(mesavar);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardisponibilidade/{id}")]
    public async Task<IActionResult> ModificarNome(int id, [FromForm] string disp)
    {
        if (_context is null) return NotFound();
        if (_context.Mesa is null) return NotFound();
        var mesavar = await _context.Mesa.FindAsync(id);
        if (mesavar is null) return NotFound();
        mesavar.Disponibilidade = disp;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
