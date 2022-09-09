using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Models;
using M06_API_Cliente.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace M06_API_Cliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("/Cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> AllCliente()
        {
            var clientes = _clienteService.GetCliente();
            if(clientes.Any() == false)
            {
                return NoContent();
            }else if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        [HttpGet("/Cliente/CPF/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> Info(string cpf)
        {
            var clienteEscolhido = _clienteService.GetClienteCpf(cpf);
            if (clienteEscolhido != null)
            {
                return Ok(clienteEscolhido);
            }
            return NotFound();
        }

        [HttpPost("/Novo/Cliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> InsertCliente(Cliente cliente)
        {
            if (!_clienteService.InsertCliente(cliente))
            {
                return BadRequest("Não foi possível criar um registro para esse cliente.");
            }
            return CreatedAtAction(nameof(InsertCliente), cliente);
        }

        [HttpPut("/Cliente/Atualizacao/{cpf}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Atualizacao(string cpf, Cliente cliente)
        {
            if (!_clienteService.UpdateCliente(cpf, cliente))
            {
                return NotFound("Este cpf não pertence a nenhum cliente cadastrado.");
            }
            _clienteService.UpdateCliente(cpf, cliente);
            var clienteAtualizado = _clienteService.GetClienteCpf(cpf);
            return Accepted(clienteAtualizado);
        }

        [HttpDelete("/Cliente/Deletar/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Cliente>> RemoveCliente(string cpf)
        {
            if (!_clienteService.DeleteCliente(cpf))
            {
                return NotFound();
            }
            _clienteService.DeleteCliente(cpf);
            return NoContent();
        }
    }
}