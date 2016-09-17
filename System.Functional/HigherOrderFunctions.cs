namespace Functional
{
	using System;
	using System.Collections.Generic;

	public static partial class HigherOrderFunctions
	{
		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Option<Y>> function)
		{
			var loop = true;

			while (loop)
			{
				yield return (function(y).Tee((t) => loop = t.IsSome())());
			}
		}

		public static IEnumerable<Y> Stream<Y>(Y y, Func<Y, Y> function, Func<Y, bool> act)
		{
			var loop = act(y);
			while (loop)
			{
				yield return (function(y).Tee(t => loop = act(t)));
			}
		}
	}
}