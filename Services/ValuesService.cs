using System.Threading.Tasks;
using WebApiEither.Repositories;

namespace WebApiEither.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesService(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }

        public async Task<Either<string, ErrorDetails>> GetValueAsync()
        {
            var retrievedValue = await _valuesRepository.GetValueAsync("someId");

            return retrievedValue.Map(StringLength);
        }

        private static Either<string, ErrorDetails> StringLength(string s) =>
            s.Length > 10 ? Either.Err(new ErrorDetails()) : Either.Ok(s.Length.ToString());
    }
}
