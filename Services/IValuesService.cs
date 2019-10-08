using System.Threading.Tasks;

namespace WebApiEither.Services
{
    public interface IValuesService
    {
        Task<Either<string, ErrorDetails>> GetValueAsync();
    }
}
