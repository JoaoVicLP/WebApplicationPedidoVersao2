using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private PedidoDbContext _context;
    public ClienteController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        if (_context.Cliente is null) return NotFound();
        return await _context.Cliente.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Cliente>> Buscar(string nome)
    {
        if (_context.Cliente is null) return NotFound();
        var Cliente = await _context.Cliente.FindAsync(nome);
        return Cliente;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente Cliente)
    {
        await _context.AddAsync(Cliente);
        await _context.SaveChangesAsync();
        return Created("", Cliente);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Cliente Cliente)
    {
        _context.Cliente.Update(Cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{cliente}")]
    public async Task<IActionResult> Excluir(string nome)
    {
        var Cliente = await _context.Cliente.FindAsync(nome);
        if (Cliente is null) return NotFound();
        _context.Cliente.Remove(Cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{nome}")]
    public async Task<IActionResult> ModificarNome(string nome, [FromForm] string email)
    {
        var Cliente = await _context.Cliente.FindAsync(nome);
        if (Cliente is null) return NotFound();
        Cliente.Nome = email;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
