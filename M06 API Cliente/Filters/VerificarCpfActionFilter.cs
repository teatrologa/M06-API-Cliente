using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Controllers;

namespace M06_API_Cliente.Filters
{
    public class VerificarCpfActionFilter : ActionFilterAttribute
    {
        public IClienteService _clienteService;
        public VerificarCpfActionFilter(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente existCliente = (Cliente)context.ActionArguments["cliente"];

            //if (_clienteService.GetClienteCpfBool(existCliente.Cpf))
            //{
            //    context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            //} //NÃO FUNCIONA

            if (_clienteService.GetClienteCpf(existCliente.Cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }




    }
}
