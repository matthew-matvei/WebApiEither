using System.Threading.Tasks;

namespace WebApiEither.Repositories
{
    public interface IValuesRepository
    {
        Task<Either<string, ErrorDetails>> GetValueAsync(string id);
    }
}
