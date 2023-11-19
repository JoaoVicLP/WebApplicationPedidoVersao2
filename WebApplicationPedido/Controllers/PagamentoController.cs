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
        if (_context is null) return NotFound();
        if (_context.Pagamento is null) return NotFound();
        return await _context.Pagamento.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public async Task<ActionResult<Pagamento>> Buscar(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Pagamento is null) return NotFound();
        var pagamentovar = await _context.Pagamento.FindAsync(id);
        if (pagamentovar is null) return NotFound();
        return pagamentovar;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<IActionResult> Cadastrar(Pagamento pagamento)
    {
        if (_context is null) return NotFound();
        if (_context.Pagamento is null) return NotFound();
        await _context.AddAsync(pagamento);
        await _context.SaveChangesAsync();
        return Created("", pagamento);
    }

    [HttpPut]
    [Route("alterar")]
    public async Task<IActionResult> Alterar(Pagamento pagamento)
    {
        if (_context is null) return NotFound();
        if (_context.Pagamento is null) return NotFound();
        var pagamentovar = await _context.Pagamento.FindAsync(pagamento.Id);
        if (pagamentovar is null) return NotFound();
        _context.Remove(pagamentovar);
        await _context.AddAsync(pagamento);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        if (_context is null) return NotFound();
        if (_context.Pagamento is null) return NotFound();
        var pagamentovar = await _context.Pagamento.FindAsync(id);
        if (pagamentovar is null) return NotFound();
        _context.Remove(pagamentovar);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
