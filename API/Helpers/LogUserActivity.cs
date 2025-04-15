using System;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Helpers;

public class LogUserActivity : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var resultContext = await next();
        if (context.HttpContext.User.Identity?.IsAuthenticated != true) return;
        var userId = resultContext.HttpContext.User.GetUserId();
        var unitofWork = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
        var user = await unitofWork.UserRepository.GetUserByIdAsync(userId);
        if(user == null) return;
        user.LastActive = DateTime.UtcNow;
        await unitofWork.Complete();
    }
}
