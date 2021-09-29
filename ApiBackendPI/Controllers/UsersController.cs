using ApiBackendPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackendPI.Models;

namespace ApiBackendPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUsers()
        {
            try 
	        {
                var users = await _userService.GetUsers();
                return Ok(users);
	        }
	        catch () 
	        {
                return BadRequest("Erro ao obter usuários!");
                //return StatusCode(StatusCode.Status500InternalServerError, "Erro ao obter usuários");
	        }
        }

        [HttpGet("UsuarioPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUsersByName([FromQuery] string nome)
        {
             try 
	         {
                var users = await _userService.GetUserByNome(nome);

                if(users == null)
                {
                    return NotFound($"Não existem usuários com o critério {nome}");
                }
                return Ok(users);
	         }
	        catch ()
	         {
                return BadRequest("Request inválido!");
                //return StatusCode(StatusCode.Status500InternalServerError, "Erro ao obter usuários");
	         }
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try 
	        {
                var user = await _userService.GetUser(id);

                if(user == null)
                {
                    return NotFound($"Não existe aluno com id={id}");

                    return Ok(user);
                }
	        }
	        catch ()
	        {
                return BadRequest("Request inválido!");
	        }
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try 
	        {
                await _userService.CreateUser(user);

                return CreatedAtRoute(nameof(GetUser), new { id = user.Id }, user); 
	        }
	        catch ()
	        {
                return BadRequest("Request inválido!");
	        }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] User user)
        {
            try 
	        {
                if (user.Id == id)
                {
                    await _userService.UpdateUser(user);

                    return Ok($"Aluno com id={id} foi atualizado com sucesso.");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
	        }
	        catch (Exception)
	        {
                return BadRequest("Request inválido!");
	        }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try 
	        {
                var user = await _userService.GetUser(id);

                if(user != null)
                {
                    await _userService.DeleteUser(user);
                    
                    return Ok($"Aluno de id={id} foi excluído com sucesso!");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não encontrado.");
                }
	        }
	        catch (Exception)
	        {
                return BadRequest("Request inválido!");
	        }
        }
    }
}
