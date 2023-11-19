using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class CondimentoController : ControllerBase
{
    private PedidoDbContext _context;
    public CondimentoController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Condimento>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        return await _context.Condimento.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Condimento>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        var condimentovar = await _context.Condimento.FindAsync(id);
        if (condimentovar is null) return NotFound();
        return condimentovar;
    }
    [HttpPost]
    [Route("cadastrar")] 
    public async Task<IActionResult> Cadastrar(Condimento condimento)
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        await _context.AddAsync(condimento);
        await _context.SaveChangesAsync();
        return Created("", condimento);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Condimento condimento)
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        var condimentovar = await _context.Condimento.FindAsync(condimento.Id);
        if (condimentovar is null) return NotFound();
        _context.Remove(condimentovar);
        await _context.AddAsync(condimento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        var condimentovar = await _context.Condimento.FindAsync(id);
        if (condimentovar is null) return NotFound();
        _context.Remove(condimentovar);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("modificarQuantidade/{id}")]
    public async Task<IActionResult> ModificarNome(int id, [FromForm] float quantidade)
    {
        if (_context is null) return NotFound();
        if (_context.Condimento is null) return NotFound();
        var condimentovar = await _context.Condimento.FindAsync(id);
        if (condimentovar is null) return NotFound();
        condimentovar.Quantidade = quantidade;
        await _context.SaveChangesAsync();
        return Ok();
    }

}