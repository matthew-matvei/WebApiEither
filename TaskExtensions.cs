using System;
using System.Threading.Tasks;

namespace WebApiEither
{
    public static class TaskExtensions
    {
        public static async Task<TOut> Then<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> mappingFunction) =>
            mappingFunction(await task);
    }
}
