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
        if (_context.Produto is null) return NotFound();
        return await _context.Produto.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Produto>> Buscar(string nome)
    {
        if (_context.Produto is null) return NotFound();
        var Produto = await _context.Produto.FindAsync(nome);
        return Produto;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Produto Produto)
    {
        await _context.AddAsync(Produto);
        await _context.SaveChangesAsync();
        return Created("", Produto);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Produto Produto)
    {
        _context.Produto.Update(Produto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{produto}")]
    public async Task<IActionResult> Excluir(string nome)
    {
        var Produto = await _context.Produto.FindAsync(nome);
        if (Produto is null) return NotFound();
        _context.Produto.Remove(Produto);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("modificardescricao/{nome}")]
    public async Task<IActionResult> ModificarNome(string nome, [FromForm] string observacao)
    {
        var Produto = await _context.Produto.FindAsync(nome);
        if (Produto is null) return NotFound();
        Produto.Nome = observacao;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
