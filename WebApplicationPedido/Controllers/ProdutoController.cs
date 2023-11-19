using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private PedidoDbContext _context;
    public ProdutoController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Produto>>> Listar()
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        return await _context.Produto.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Produto>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        var produtovar = await _context.Produto.FindAsync(id);
        if (produtovar is null) return NotFound();
        return produtovar;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Produto produto)
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        await _context.AddAsync(produto);
        await _context.SaveChangesAsync();
        return Created("", produto);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Produto produto)
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        var produtovar = await _context.Produto.FindAsync(produto.Id);
        if (produtovar is null) return NotFound();
        _context.Remove(produtovar);
        await _context.AddAsync(produto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        var produtovar = await _context.Produto.FindAsync(id);
        if (produtovar is null) return NotFound();
        _context.Remove(produtovar);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    [Route("modificarobservação/{id}")]
    public async Task<IActionResult> ModificarNome(int id, [FromForm] string observacao)
    {
        if (_context is null) return NotFound();
        if (_context.Produto is null) return NotFound();
        var produtovar = await _context.Produto.FindAsync(id);
        if (produtovar is null) return NotFound();
        produtovar.Observacao = observacao;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
