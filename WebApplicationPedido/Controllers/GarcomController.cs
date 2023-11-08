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
        if (_context.Garcom is null) return NotFound();
        return await _context.Garcom.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Garcom>> Buscar(string nome)
    {
        if (_context.Garcom is null) return NotFound();
        var Garcom = await _context.Garcom.FindAsync(nome);
        return Garcom;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Garcom Garcom)
    {
        await _context.AddAsync(Garcom);
        await _context.SaveChangesAsync();
        return Created("", Garcom);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Garcom Garcom)
    {
        _context.Garcom.Update(Garcom);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{garcom}")]
    public async Task<IActionResult> Excluir(string nome)
    {
        var Garcom = await _context.Garcom.FindAsync(nome);
        if (Garcom is null) return NotFound();
        _context.Garcom.Remove(Garcom);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
