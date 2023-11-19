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
        if (_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound();
        return await _context.Cliente.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Cliente>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound(); 
        var clientevar = await _context.Cliente.FindAsync(id);
        if (clientevar is null) return NotFound();
        return clientevar;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Cliente cliente)
    {
        if(_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound();
        await _context.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return Created("", cliente);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Cliente cliente)
    {
        if (_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound();
        var clientevar = await _context.Cliente.FindAsync(cliente.Id);
        if (clientevar is null) return NotFound();
        _context.Remove(clientevar);
        await _context.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound();
        var clientevar = await _context.Cliente.FindAsync(id);
        if (clientevar is null) return NotFound();
        _context.Remove(clientevar);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("modificarobservação/{id}")]
    public async Task<IActionResult> ModificarNome(int id, [FromForm] string observacoes)
    {
        if (_context is null) return NotFound();
        if (_context.Cliente is null) return NotFound();
        var clientevar = await _context.Cliente.FindAsync(id);
        if (clientevar is null) return NotFound();
        clientevar.Observacoes = observacoes;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
