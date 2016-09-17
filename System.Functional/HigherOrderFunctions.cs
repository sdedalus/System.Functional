namespace Functional
{
	using System;
	using System.Collections.Generic;

	public static partial class HigherOrderFunctions
	{
		//// var S = new Func<dynamic, Func<dynamic, Func<dynamic, dynamic>>>(x => y => z => x(z)(y(z)));
		//public static Func<Func<T1, T2>, Func<T1, TResult>> S<T1, T2, TResult>(Func<T1, Func<T2, TResult>> x) => y => z => x(z)(y(z));

		//// var K = new Func<dynamic, Func<dynamic, dynamic>>(x => y => x);
		//public static Func<Y, X> K<X, Y>(X x) => _ => x;

		//// var I = new Func<dynamic, dynamic>(x => x);
		//public static X I<X>(X x) => x;

		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Option<Y>> function)
		{
			bool loop = true;

			while (loop)
			{
				yield return (function(y).Tee((t) => loop = t.IsSome())());
			}
		}

		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Y> function, Func<Y, bool> act)
		{
			bool loop = act(y);
			while (loop)
			{
				yield return (function(y).Tee(t => loop = act(t)));
			}
		}
	}
}