using System;

namespace Functional
{
	public static partial class HigherOrderFunctions
	{
		public static Func<Tuple<T1>, R> Tupalize<T1, R>(this Func<T1, R> function) =>
			(a) => function(a.Item1);

		public static Func<Tuple<T1, T2>, R> Tupalize<T1, T2, R>(this Func<T1, T2, R> function) =>
			(a) => function(a.Item1, a.Item2);

		public static Func<Tuple<T1, T2, T3>, R> Tupalize<T1, T2, T3, R>(this Func<T1, T2, T3, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3);

		public static Func<Tuple<T1, T2, T3, T4>, R> Tupalize<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3, a.Item4);

		public static Func<Tuple<T1, T2, T3, T4, T5>, R> Tupalize<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3, a.Item4, a.Item5);

		public static Func<Tuple<T1, T2, T3, T4, T5, T6>, R> Tupalize<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3, a.Item4, a.Item5, a.Item6);

		public static Func<Tuple<T1, T2, T3, T4, T5, T6, T7>, R> Tupalize<T1, T2, T3, T4, T5, T6, T7, R>(this Func<T1, T2, T3, T4, T5, T6, T7, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3, a.Item4, a.Item5, a.Item6, a.Item7);

		public static Func<Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>, R> Tupalize<T1, T2, T3, T4, T5, T6, T7, T8, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, R> function) =>
			(a) => function(a.Item1, a.Item2, a.Item3, a.Item4, a.Item5, a.Item6, a.Item7, a.Rest.Item1);

		public static Func<T1, R> Detupalize<T1, R>(this Func<Tuple<T1>, R> function) =>
			(a) => function(Tuple.Create(a));

		public static Func<T1, T2, R> Detupalize<T1, T2, R>(this Func<Tuple<T1, T2>, R> function) =>
			(a, b) => function(Tuple.Create(a, b));

		public static Func<T1, T2, T3, R> Detupalize<T1, T2, T3, R>(this Func<Tuple<T1, T2, T3>, R> function) =>
			(a, b, c) => function(Tuple.Create(a, b, c));

		public static Func<T1, T2, T3, T4, R> Detupalize<T1, T2, T3, T4, R>(this Func<Tuple<T1, T2, T3, T4>, R> function) =>
			(a, b, c, d) => function(Tuple.Create(a, b, c, d));

		public static Func<T1, T2, T3, T4, T5, R> Detupalize<T1, T2, T3, T4, T5, R>(this Func<Tuple<T1, T2, T3, T4, T5>, R> function) =>
			(a, b, c, d, e) => function(Tuple.Create(a, b, c, d, e));

		public static Func<T1, T2, T3, T4, T5, T6, R> Detupalize<T1, T2, T3, T4, T5, T6, R>(this Func<Tuple<T1, T2, T3, T4, T5, T6>, R> function) =>
			(a, b, c, d, e, f) => function(Tuple.Create(a, b, c, d, e, f));

		public static Func<T1, T2, T3, T4, T5, T6, T7, R> Detupalize<T1, T2, T3, T4, T5, T6, T7, R>(this Func<Tuple<T1, T2, T3, T4, T5, T6, T7>, R> function) =>
			(a, b, c, d, e, f, g) => function(Tuple.Create(a, b, c, d, e, f, g));

		public static Func<T1, T2, T3, T4, T5, T6, T7, T8, R> Detupalize<T1, T2, T3, T4, T5, T6, T7, T8, R>(this Func<Tuple<T1, T2, T3, T4, T5, T6, T7, Tuple<T8>>, R> function) =>
			(a, b, c, d, e, f, g, h) => function(Tuple.Create(a, b, c, d, e, f, g, h));
	}
}