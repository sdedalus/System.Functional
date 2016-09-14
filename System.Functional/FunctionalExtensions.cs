namespace Functional
{
	using System;

	public static class FunctionalExtensions
	{
		/// <summary>
		/// Maps the specified TSource type to a TResult type using the supplied function.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="this">The this.</param>
		/// <param name="fn">The function.</param>
		/// <returns></returns>
		public static TResult Map<TSource, TResult>(
			this TSource @this,
			Func<TSource, TResult> fn) => fn(@this);

		public static T Tee<T>(this T @this, Action<T> act)
		{
			act?.Invoke(@this);
			return @this;
		}
	}
}