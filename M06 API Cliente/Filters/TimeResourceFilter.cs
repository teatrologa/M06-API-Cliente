using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace M06_API_Cliente.Filters
{
    public class TimeResourceFilter : IResourceFilter
    {
        Stopwatch tempoExecucao = new();
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            tempoExecucao.Stop();
            var tempoExecucaoS = tempoExecucao.ElapsedMilliseconds / 1000;
            Console.WriteLine($"O tempo total de execução dessa operação foi de: {tempoExecucaoS}s");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            tempoExecucao.Start();
        }
    }
}
