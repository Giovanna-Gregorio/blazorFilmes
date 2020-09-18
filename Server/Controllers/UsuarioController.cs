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
    }
}