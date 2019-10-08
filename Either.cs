using System;
using System.Threading.Tasks;

namespace WebApiEither
{
    public class Either<TSuccess, TError> where TSuccess : class where TError : class
    {
        public bool IsError { get; }
        public TSuccess Value { get; }
        public TError Error { get; }

        private Either(TSuccess value)
        {
            Value = value;
            Error = default(TError);
        }

        private Either(TError error)
        {
            Value = default(TSuccess);
            Error = error;
        }

        public Either<TSuccess, TError> Map(Func<TSuccess, Either<TSuccess, TError>> mappingFunction)
        {
            if (IsError)
                return Err(Error);

            return mappingFunction(Value);
        }

        private static Either<TSuccess, TError> Ok(TSuccess value) =>
            new Either<TSuccess, TError>(value);

        private static Either<TSuccess, TError> Err(TError error) =>
            new Either<TSuccess, TError>(error);

        public static implicit operator Either<TSuccess, TError>(Either either) =>
            either.IsError ?
                new Either<TSuccess, TError>(either.Value as TSuccess)
                : new Either<TSuccess, TError>(either.Value as TError);
    }

    public class Either
    {
        public bool IsError { get; }
        public object Value { get; }
        public object Error { get; }

        private Either(bool isError, object value)
        {
            IsError = isError;
            Value = isError ? null : value;
            Error = isError ? value : null;
        }

        public static Either Ok(object value) =>
            new Either(false, value);

        public static Either Err(object error) =>
            new Either(true, error);
    }
}
