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
        if (_context.Desconto is null) return NotFound();
        return await _context.Desconto.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Desconto>> Buscar(string nome)
    {
        if (_context.Desconto is null) return NotFound();
        var Desconto = await _context.Desconto.FindAsync(nome);
        return Desconto;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Desconto Desconto)
    {
        await _context.AddAsync(Desconto);
        await _context.SaveChangesAsync();
        return Created("", Desconto);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Desconto Desconto)
    {
        _context.Desconto.Update(Desconto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{desconto}")]
    public async Task<IActionResult> Excluir(string nome)
    {
        var Desconto = await _context.Desconto.FindAsync(nome);
        if (Desconto is null) return NotFound();
        _context.Desconto.Remove(Desconto);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
