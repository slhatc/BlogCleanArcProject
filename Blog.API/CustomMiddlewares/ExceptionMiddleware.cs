
using Blog.Application.Base;
using FluentValidation;

namespace Blog.API.CustomMiddlewares
{
    public class ExceptionMiddleware (RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
			try
			{
				await next(context);
            }
			catch (ValidationException ex)
			{
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = new BaseResult<object>()
                {
                    Errors = ex.Errors
                        .GroupBy(f => f.PropertyName)
                        .Select(x=> new Error
                        {
                            PropertyName = x.Key,
                            ErrorMessage = string.Join(", ", x.Select(e => e.ErrorMessage))
                        })
                };
                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new {ErrorMessage = ex.Message});
            }
        }
    }
}
