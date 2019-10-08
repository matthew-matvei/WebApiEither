using Microsoft.AspNetCore.Mvc;

namespace WebApiEither.Controllers
{
    public static class EitherExtensions
    {
        public static ActionResult<TResponse> ToResponse<TResponse, TError>(
            this Either<TResponse, TError> either) where TResponse : class where TError : class =>
                either.IsError ?
                    new BadRequestObjectResult(either.Error) :
                    new ActionResult<TResponse>(either.Value);
    }
}
