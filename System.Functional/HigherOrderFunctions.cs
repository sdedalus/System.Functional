namespace Functional
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	public static partial class HigherOrderFunctions
	{
		/// <summary>
		/// Streams the specified y.
		/// </summary>
		/// <typeparam name="Y"></typeparam>
		/// <param name="y">The y.</param>
		/// <param name="function">The function.</param>
		/// <returns></returns>
		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Option<Y>> function)
		{
			var loop = true;

			while (loop)
			{
				yield return (function(y).Tee((t) => loop = t.IsSome())());
			}
		}

		/// <summary>
		/// Streams the specified y.
		/// </summary>
		/// <typeparam name="Y"></typeparam>
		/// <param name="y">The y.</param>
		/// <param name="function">The function.</param>
		/// <param name="act">The act.</param>
		/// <returns></returns>
		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Y> function, Func<Y, bool> act)
		{
			var loop = act(y);
			while (loop)
			{
				yield return (function(y).Tee(t => loop = act(t)));
			}
		}

		/// <summary>
		/// Using the specified factory.
		/// </summary>
		/// <typeparam name="TDisposable">The type of the disposable.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="factory">The factory.</param>
		/// <param name="map">The map.</param>
		/// <returns></returns>
		public static TResult Using<TDisposable, TResult>(
		Func<TDisposable> factory,
		Func<TDisposable, TResult> map)
		where TDisposable : IDisposable
		{
			using (var disposable = factory())
			{
				return map(disposable);
			}
		}

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

		/// <summary>
		/// Maps the specified function. For IEnumerable Map is just a
		/// wrapper around Select this is only here for naming consistency
		/// with the single item map.
		/// </summary>
		/// <typeparam name="TSource">The type of the source.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="this">The this.</param>
		/// <param name="fn">The function.</param>
		/// <returns></returns>
		public static IEnumerable<TResult> Map<TSource, TResult>(
			this IEnumerable<TSource> @this,
			Func<TSource, TResult> fn) where TSource : IEnumerable => @this.Select(v => fn(v));

		/// <summary>
		/// Tees the specified act.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="this">The this.</param>
		/// <param name="act">The act.</param>
		/// <returns></returns>
		public static T Tee<T>(this T @this, Action<T> act)
		{
			act?.Invoke(@this);
			return @this;
		}

		/// <summary>
		/// Tees all.
		/// </summary>
		/// <typeparam name="T">The Type</typeparam>
		/// <param name="this">The this.</param>
		/// <param name="act">The act.</param>
		/// <returns></returns>
		public static IEnumerable<T> TeeAll<T>(this IEnumerable<T> @this, Action<T> act)
		{
			foreach (T item in @this)
			{
				item.Tee(act);
				yield return item;
			}
		}
	}
}