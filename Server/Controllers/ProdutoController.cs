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

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody]Produto produto)
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
            catch(Exception e)
            {
                return View(e);
            }    
        }
    }
}