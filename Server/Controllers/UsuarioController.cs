using BlazorFilmes.Shared;
using BlazorFilmes.Server;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorFilmes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDBContext db;

        public UsuarioController(ApplicationDBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var users = await db.Usuario.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var user = await db.Usuario.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Ok(user);
        }

        //Action/Metodo para adicionar/Post um Usuário
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody]Usuario user)
        {
            //TODO: Adicionar novo usuario (user) uma lista
            try
            {
                var newUser = new Usuario
                {
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateBirth = user.DateBirth,
                    Email = user.Email,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    Accept = user.Accept
                };

                db.Add(newUser);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return View(e);
            }    
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(usuario).State = EntityState.Modified;
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
        public async Task<ActionResult<Usuario>>Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            db.Usuario.Remove(usuario);
            await db.SaveChangesAsync();
            return usuario;
        }
    }
}