namespace DrinkServer.Utils
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    /// Provides assertions for use as method preconditions.
    /// </summary>
    public static class Precond
    {
        /// <summary>
        /// Require that the given value is not null. If 'value' is null, throws an 
        /// ArgumentNullException.
        /// </summary>
        /// <param name="value">Value that must not be null.</param>
        public static void IsNotNull(object value)
        {
            Precond.Requires<ArgumentNullException>(value != null);
        }

        /// <summary>
        /// Require that the given value is not null. If 'value' is null, throws an 
        /// ArgumentNullException.
        /// </summary>
        /// <param name="value">value that must not be null.</param>
        /// <param name="paramName">name of the parameter that holds 'value'.</param>
        public static void IsNotNull(object value, string paramName)
        {
            Precond.Requires<ArgumentNullException>(value != null, paramName);
        }

        /// <summary>
        /// Require that the given value is not null. If 'value' is null, throws an exception of 
        /// the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        public static void IsNotNull<TException>(object value)
            where TException : Exception, new()
        {
            Precond.Requires<TException>(value != null);
        }

        /// <summary>
        /// Require that the given value is not null. If 'value' is null, throws an exception of
        /// the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        /// <param name="message">A message included if the exception is thrown.</param>
        public static void IsNotNull<TException>(object value, string message)
            where TException : Exception, new()
        {
            Precond.Requires<TException>(value != null, message);
        }

        /// <summary>
        /// Require that the given value is null. If 'value' is not null, throws an
        /// InvalidOperationException.
        /// </summary>
        /// <param name="value">Value that must be null.</param>
        public static void IsNull(object value)
        {
            Precond.Requires<InvalidOperationException>(value == null);
        }

        /// <summary>
        /// Require that the given value is null. If 'value' is not null, throws an
        /// InvalidOperationException.
        /// </summary>
        /// <param name="value">value that must not be null.</param>
        /// <param name="message">A message included if the exception is thrown.</param>
        public static void IsNull(object value, string message)
        {
            Precond.Requires<InvalidOperationException>(value == null, message);
        }

        /// <summary>
        /// Require that the given value is null. If 'value' is not null, throws an exception of
        /// the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        public static void IsNull<TException>(object value)
            where TException : Exception, new()
        {
            Precond.Requires<TException>(value == null);
        }

        /// <summary>
        /// Require that the given value is null. If 'value' is not null, throws an exception of
        /// the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="value">The value that must not be null.</param>
        /// <param name="message">A message included if the exception is thrown.</param>
        public static void IsNull<TException>(object value, string message)
            where TException : Exception, new()
        {
            Precond.Requires<TException>(value == null, message);
        }

        /// <summary>
        /// Require that the given predicate is true. If 'predicate' is false, throws an
        /// InvalidOperationException.
        /// </summary>
        /// <param name="predicate">The bool that must be true.</param>
        public static void Requires(bool predicate)
        {
            Precond.Requires<InvalidOperationException>(predicate);
        }

        /// <summary>
        /// Require that the given predicate is true. If 'predicate' is false, throws an
        /// InvalidOperationException.
        /// </summary>
        /// <param name="predicate">The bool that must be true.</param>
        public static void Requires(bool predicate, string message)
        {
            Precond.Requires<InvalidOperationException>(predicate, message);
        }

        /// <summary>
        /// Require that the given predicate is true. If 'predicate' is false, throws an exception
        /// of the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="predicate">The bool that must be true.</param>
        /// <param name="message">A message included if the exception is thrown.</param>
        public static void Requires<TException>(bool predicate)
            where TException : Exception, new()
        {
            if (!predicate)
            {
                throw new TException();
            }
        }

        /// <summary>
        /// Require that the given predicate is true. If 'predicate' is false, throws an exception
        /// of the given type.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="predicate">The bool that must be true.</param>
        /// <param name="message">A message included if the exception is thrown.</param>
        public static void Requires<TException>(bool predicate, string message)
            where TException : Exception, new()
        {
            if (!predicate)
            {
                var cons = typeof(TException).GetConstructor(new Type[] { typeof(string) });

                if (cons != null)
                {
                    throw cons.Invoke(new object[] { message }) as TException;
                }
                else
                {
                    Debug.WriteLine(message);
                    throw new TException();
                }
            }
        }
    }
}
