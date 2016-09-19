namespace Functional
{
	using System;
	using System.Collections.Concurrent;

	public static partial class HigherOrderFunctions
	{
		private static Func<T1, R> SafeMemoize<T1, R>(this Func<T1, R> function)
		{
			var cache = new ConcurrentDictionary<T1, R>();
			var syncMap = new ConcurrentDictionary<T1, object>();
			return a =>
			{
				R r;
				if (!cache.TryGetValue(a, out r))
				{
					var sync = syncMap.GetOrAdd(a, new object());
					lock (sync)
					{
						r = cache.GetOrAdd(a, function);
					}
					syncMap.TryRemove(a, out sync);
				}
				return r;
			};
		}

		// This is not the best approach since it relies on an intermediate tuple argument but will
		// serve until I can solve the problem of lost scope that happens when SafeMemoize is called
		// in a chain following Curry.
		public static Func<T1, R> Memoize<T1, R>(Func<T1, R> function) =>
			(a) => function
			.SafeMemoize()(a);

		public static Func<T1, T2, R> Memoize<T1, T2, R>(Func<T1, T2, R> function) =>
			 function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, R> Memoize<T1, T2, T3, R>(Func<T1, T2, T3, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, T4, R> Memoize<T1, T2, T3, T4, R>(Func<T1, T2, T3, T4, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, T4, T5, R> Memoize<T1, T2, T3, T4, T5, R>(Func<T1, T2, T3, T4, T5, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, T4, T5, T6, R> Memoize<T1, T2, T3, T4, T5, T6, R>(Func<T1, T2, T3, T4, T5, T6, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, T4, T5, T6, T7, R> Memoize<T1, T2, T3, T4, T5, T6, T7, R>(Func<T1, T2, T3, T4, T5, T6, T7, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, R> Memoize<T1, T2, T3, T4, T5, T6, T7, T8, R>(Func<T1, T2, T3, T4, T5, T6, T7, T8, R> function) =>
			function
			.Tupled()
			.SafeMemoize()
			.Detupled();
	}
}