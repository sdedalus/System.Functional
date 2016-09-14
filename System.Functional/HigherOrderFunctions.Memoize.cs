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

		public static Func<T1, R> Memoize<T1, R>(Func<T1, R> function) =>
			(a) => function
			.SafeMemoize()(a);

		public static Func<T1, T2, R> Memoize<T1, T2, R>(Func<T1, T2, R> function) =>
			(a, b) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b);

		public static Func<T1, T2, T3, R> Memoize<T1, T2, T3, R>(Func<T1, T2, T3, R> function) =>
			(a, b, c) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b)
			.SafeMemoize()(c);

		public static Func<T1, T2, T3, T4, R> Memoize<T1, T2, T3, T4, R>(Func<T1, T2, T3, T4, R> function) =>
			(a, b, c, d) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b)
			.SafeMemoize()(c)
			.SafeMemoize()(d);

		public static Func<T1, T2, T3, T4, T5, R> Memoize<T1, T2, T3, T4, T5, R>(Func<T1, T2, T3, T4, T5, R> function) =>
			(a, b, c, d, e) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b)
			.SafeMemoize()(c)
			.SafeMemoize()(d)
			.SafeMemoize()(e);

		public static Func<T1, T2, T3, T4, T5, T6, R> Memoize<T1, T2, T3, T4, T5, T6, R>(Func<T1, T2, T3, T4, T5, T6, R> function) =>
			(a, b, c, d, e, f) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b)
			.SafeMemoize()(c)
			.SafeMemoize()(d)
			.SafeMemoize()(e)
			.SafeMemoize()(f);

		public static Func<T1, T2, T3, T4, T5, T6, T7, R> Memoize<T1, T2, T3, T4, T5, T6, T7, R>(Func<T1, T2, T3, T4, T5, T6, T7, R> function) =>
			(a, b, c, d, e, f, g) => function
			.Curry()
			.SafeMemoize()(a)
			.SafeMemoize()(b)
			.SafeMemoize()(c)
			.SafeMemoize()(d)
			.SafeMemoize()(e)
			.SafeMemoize()(f)
			.SafeMemoize()(g);
	}
}