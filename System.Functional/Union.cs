using System;

namespace Functional
{
	public static class Union
	{
		public static IUnion<B> Bind<A, B>(this IUnion<A> a, Func<A, IUnion<B>> func)
		{
			var justa = a.AsOption();
			return justa.IsNone() ?
				new Union<B>() :
				func(justa.Select(c => c));
		}

		public static Option<B> Select<A, B>(this IUnion<A> a, Func<A, B> select)
		{
			return a.Bind(aval => new Union<B>(select(aval))).AsOption();
		}

		public static IUnion<TSource> Where<TSource>(this IUnion<TSource> source, Func<TSource, bool> predicate)
		{
			if (source.AsOption().IsSome())
			{
				if (predicate(source.AsOption()))
				{
					return source;
				}

				return new Union<TSource>();
			}

			return source;
		}

		/// <summary>
		/// Matches the specified union.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="union">The union.</param>
		/// <returns></returns>
		public static bool Match<T>(this IUnion union)
		{
			var myUnion = union as IUnion<T>;
			return myUnion.AsOption().IsSome();
		}

		/// <summary>
		/// Matches the specified condition.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="union">The union.</param>
		/// <param name="condition">The condition.</param>
		/// <returns></returns>
		public static bool Match<T>(this IUnion union, Func<T, bool> condition)
		{
			var myUnion = union as IUnion<T>;
			return myUnion.AsOption().Where(c => condition(c)).IsSome();
		}

		public static T Value<T>(this IUnion union)
		{
			var myUnion = union as IUnion<T>;
			return myUnion.AsOption();
		}

		/// <summary>
		/// To the error union.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Err">The type of the rr.</typeparam>
		/// <param name="factory">The factory.</param>
		/// <returns></returns>
		public static IUnion ToErrorUnion<T, Err>(this Func<T> factory)
			where Err : SystemException
		{
			try
			{
				return new Union<T, Err>(factory());
			}
			catch (Err ex)
			{
				return new Union<T, Err>(ex);
			}
		}

		/// <summary>
		/// To the error union.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="factory">The factory.</param>
		/// <returns></returns>
		public static IUnion ToErrorUnion<T>(this Func<T> factory)
		{
			try
			{
				return new Union<T, SystemException>(factory());
			}
			catch (SystemException ex)
			{
				return new Union<T, SystemException>(ex);
			}
		}
	}

	public interface IUnion
	{
	}

	public interface IUnion<T>
	{
		Option<T> AsOption();
	}

	public class Union<T1> : IUnion, IUnion<T1>
	{
		private readonly Option<T1> internalValue;

		public Union()
		{ }

		public Union(T1 value)
		{
			this.internalValue = value;
		}

		Option<T1> IUnion<T1>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2> : Union<T1>, IUnion, IUnion<T2>
	{
		private readonly Option<T2> internalValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 value)
		{
			this.internalValue = value;
		}

		Option<T2> IUnion<T2>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3> : Union<T1, T2>, IUnion, IUnion<T3>
	{
		private readonly Option<T3> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value)
		{
			this.internalValue = value;
		}

		Option<T3> IUnion<T3>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3, T4> : Union<T1, T2, T3>, IUnion, IUnion<T4>
	{
		private readonly Option<T4> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value) : base(value)
		{
		}

		public Union(T4 value)
		{
			this.internalValue = value;
		}

		Option<T4> IUnion<T4>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3, T4, T5> : Union<T1, T2, T3, T4>, IUnion, IUnion<T5>
	{
		private readonly Option<T5> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value) : base(value)
		{
		}

		public Union(T4 value) : base(value)
		{
		}

		public Union(T5 value)
		{
			this.internalValue = value;
		}

		Option<T5> IUnion<T5>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3, T4, T5, T6> : Union<T1, T2, T3, T4, T5>, IUnion, IUnion<T6>
	{
		private readonly Option<T6> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value) : base(value)
		{
		}

		public Union(T4 value) : base(value)
		{
		}

		public Union(T5 value) : base(value)
		{
		}

		public Union(T6 value)
		{
			this.internalValue = value;
		}

		Option<T6> IUnion<T6>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7> : Union<T1, T2, T3, T4, T5, T6>, IUnion, IUnion<T7>
	{
		private readonly Option<T7> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value) : base(value)
		{
		}

		public Union(T4 value) : base(value)
		{
		}

		public Union(T5 value) : base(value)
		{
		}

		public Union(T6 value) : base(value)
		{
		}

		public Union(T7 value)
		{
			this.internalValue = value;
		}

		Option<T7> IUnion<T7>.AsOption()
		{
			return internalValue;
		}
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7, T8> : Union<T1, T2, T3, T4, T5, T6, T7>, IUnion, IUnion<T8>
	{
		private readonly Option<T8> internalValue;

		protected Union()
		{ }

		public Union(T1 value) : base(value)
		{
		}

		public Union(T2 value) : base(value)
		{
		}

		public Union(T3 value) : base(value)
		{
		}

		public Union(T4 value) : base(value)
		{
		}

		public Union(T5 value) : base(value)
		{
		}

		public Union(T6 value) : base(value)
		{
		}

		public Union(T7 value) : base(value)
		{
		}

		public Union(T8 value)
		{
			this.internalValue = value;
		}

		Option<T8> IUnion<T8>.AsOption()
		{
			return internalValue;
		}
	}
}