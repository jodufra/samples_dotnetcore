using System;

namespace Application.Common.Extensions
{
    public static class MaybeMonad
    {
        public static TResult With<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            if (evaluator == null)
            {
                throw new ArgumentNullException(nameof(evaluator));
            }

            return obj != null ? evaluator(obj) : null;
        }

        public static TResult WithValue<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
            where TInput : struct
        {
            if (evaluator == null)
            {
                throw new ArgumentNullException(nameof(evaluator));
            }

            return evaluator(obj);
        }

        public static TInput If<TInput>(this TInput obj, Func<TInput, bool> evaluator)
            where TInput : class
        {
            if (evaluator == null)
            {
                throw new ArgumentNullException(nameof(evaluator));
            }

            return obj != null && evaluator(obj) ? obj : null;
        }

        public static TInput Do<TInput>(this TInput obj, Action<TInput> action)
            where TInput : class
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (obj != null)
            {
                action(obj);
            }
            return obj;
        }

        public static TResult Result<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator, TResult defaultValue)
            where TInput : class
        {
            if (evaluator == null)
            {
                throw new ArgumentNullException(nameof(evaluator));
            }

            return obj != null ? evaluator(obj) : defaultValue;
        }
    }
}
