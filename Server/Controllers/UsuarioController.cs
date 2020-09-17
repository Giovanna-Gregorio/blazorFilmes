using BlazorFilmes.Shared;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorFilmes.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("List")]
        public IEnumerable<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario() { Title = "Sr", FirstName = "Joao", LastName = "das Cove",
                                Email = "teste@teste.com", DateBirth = DateTime.Now, Password = "123456",
                                ConfirmPassword = "123456", Accept = true },

                new Usuario() { Title = "Sr", FirstName = "Joao2", LastName = "das Cove2",
                                Email = "teste@teste.com", DateBirth = DateTime.Now, Password = "123456",
                                ConfirmPassword = "123456", Accept = true },
            };

            return usuarios;
        }

        //Action/Metodo para adicionar/Post um Usuário
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody]Usuario usuario)
        {
            //TODO: Adicionar novo usuario (user) uma lista
            Console.WriteLine("teste", usuario.ToString());
            return null;    
        }
    }
}