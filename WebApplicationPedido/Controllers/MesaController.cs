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
        if (_context.Mesa is null) return NotFound();
        return await _context.Mesa.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{numero}")]

    public async Task<ActionResult<Mesa>> Buscar(int numero)
    {
        if (_context.Mesa is null) return NotFound();
        var Mesa = await _context.Mesa.FindAsync(numero);
        return Mesa;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Mesa Mesa)
    {
        await _context.AddAsync(Mesa);
        await _context.SaveChangesAsync();
        return Created("", Mesa);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Mesa Mesa)
    {
        _context.Mesa.Update(Mesa);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{mesa}")]
    public async Task<IActionResult> Excluir(int numero)
    {
        var Mesa = await _context.Mesa.FindAsync(numero);
        if (Mesa is null) return NotFound();
        _context.Mesa.Remove(Mesa);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{numero}")]
    public async Task<IActionResult> ModificarNome(int numero, [FromForm] int capacidade)
    {
        var Mesa = await _context.Mesa.FindAsync(numero);
        if (Mesa is null) return NotFound();
        Mesa.Numero = capacidade;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
