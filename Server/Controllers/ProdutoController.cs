using System;
using System.Threading.Tasks;
using BlazorFilmes.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorFilmes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ApplicationDBContext db;

        public ProdutoController(ApplicationDBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var produto = await db.Produto.ToListAsync();
            return Ok(produto);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var produto = await db.Produto.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Ok(produto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            //TODO: Adicionar novo produto (produto) uma lista
            try
            {
                var newProduto = new Produto
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Valor = produto.Valor
                };

                db.Add(newProduto);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(produto).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw (ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var produto = await db.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            db.Produto.Remove(produto);
            await db.SaveChangesAsync();
            return produto;
        }
    }
}
