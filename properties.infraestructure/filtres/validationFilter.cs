using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace properties.infraestructure.filtres
{
    public class validationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid) {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            await next();
        }
    }
}
