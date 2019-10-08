using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiEither.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private IDictionary<string, string> _valueBucket;

        public ValuesRepository()
        {
            _valueBucket = new Dictionary<string, string>();
        }

        public Task<Either<string, ErrorDetails>> GetValueAsync(string id) =>
            Task.FromResult<Either<string, ErrorDetails>>(
                _valueBucket.ContainsKey(id) ?
                    Either.Ok(_valueBucket[id]) :
                    Either.Err(new ErrorDetails()));
    }
}
