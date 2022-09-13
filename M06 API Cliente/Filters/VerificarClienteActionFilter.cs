using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace M06_API_Cliente.Filters
{
    public class VerificarClienteActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public VerificarClienteActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente existCliente = (Cliente)context.ActionArguments["cliente"];

            if (_clienteService.GetClienteCpfBool(existCliente.Cpf) == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
                Console.WriteLine("Não existe neenhum registro com esse cpf");
            }
        }
    }
}
