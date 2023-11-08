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
        if (_context.Condimento is null) return NotFound();
        return await _context.Condimento.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Condimento>> Buscar(string nome)
    {
        if (_context.Cliente is null) return NotFound();
        var Condimento = await _context.Condimento.FindAsync(nome);
        return Condimento;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Condimento Condimento)
    {
        await _context.AddAsync(Condimento);
        await _context.SaveChangesAsync();
        return Created("", Condimento);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Condimento Condimento)
    {
        _context.Condimento.Update(Condimento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{cliente}")]
    public async Task<IActionResult> Excluir(string nome)
    {
        var Condimento = await _context.Condimento.FindAsync(nome);
        if (Condimento is null) return NotFound();
        _context.Condimento.Remove(Condimento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{nome}")]
    public async Task<IActionResult> ModificarNome(string nome, [FromForm] string quantidade)
    {
        var Condimento = await _context.Condimento.FindAsync(nome);
        if (Condimento is null) return NotFound();
        Condimento.Nome = quantidade;
        await _context.SaveChangesAsync();
        return Ok();
    }

}