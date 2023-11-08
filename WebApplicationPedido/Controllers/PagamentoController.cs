using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers;

[ApiController]
[Route("[controller]")]
public class PagamentoController : ControllerBase
{
    private PedidoDbContext _context;
    public PagamentoController(PedidoDbContext context)
    {
        _context = context;
    }

    [HttpGet()]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Listar()
    {
        if (_context.Pagamento is null) return NotFound();
        return await _context.Pagamento.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{nome}")]

    public async Task<ActionResult<Pagamento>> Buscar(string Formadepagamento)
    {
        if (_context.Pagamento is null) return NotFound();
        var Pagamento = await _context.Pagamento.FindAsync(Formadepagamento);
        return Pagamento;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pagamento Pagamento)
    {
        await _context.AddAsync(Pagamento);
        await _context.SaveChangesAsync();
        return Created("", Pagamento);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Pagamento Pagamento)
    {
        _context.Pagamento.Update(Pagamento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{pagamento}")]
    public async Task<IActionResult> Excluir(string Formadepagamento)
    {
        var Pagamento = await _context.Pagamento.FindAsync(Formadepagamento);
        if (Pagamento is null) return NotFound();
        _context.Pagamento.Remove(Pagamento);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
