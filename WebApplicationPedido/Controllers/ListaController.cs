using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Models;

namespace Pedido.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaController : ControllerBase
    {
        private PedidoDbContext _context;

        public ListaController(PedidoDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Lista>>> Listar()
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            return await _context.Lista.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Lista>> Buscar(int id)
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            var listaVar = await _context.Lista.FindAsync(id);
            if (listaVar is null) return NotFound();
            return listaVar;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Lista lista)
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            await _context.AddAsync(lista);
            await _context.SaveChangesAsync();
            return Created("", lista);
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<IActionResult> Alterar(Lista lista)
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            var listaVar = await _context.Lista.FindAsync(lista.Id);
            if (listaVar is null) return NotFound();
            _context.Remove(listaVar);
            await _context.AddAsync(lista);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete()]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            var listaVar = await _context.Lista.FindAsync(id);
            if (listaVar is null) return NotFound();
            _context.Remove(listaVar);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch()]
        [Route("modificarstatus/{id}")]
        public async Task<IActionResult> ModificarObservacao(int id, [FromForm] string status)
        {
            if (_context is null) return NotFound();
            if (_context.Lista is null) return NotFound();
            var listaVar = await _context.Lista.FindAsync(id);
            if (listaVar is null) return NotFound();
            listaVar.Status = status;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
