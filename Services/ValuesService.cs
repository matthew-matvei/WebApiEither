using System;
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

        public Task<Either<string, ErrorDetails>> GetValueAsync() =>
            _valuesRepository
                .GetValueAsync("someId")
                .Then(retrievedValue => retrievedValue.Map(StringLength));

        private static Either<string, ErrorDetails> StringLength(string s) =>
            s.Length > 10 ? Either.Err(new ErrorDetails()) : Either.Ok(s.Length.ToString());
    }
}
