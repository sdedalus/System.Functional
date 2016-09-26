using System;
using static Functional.HigherOrderFunctions;

namespace Functional
{
	public static class Union
	{
		////public static IUnion<B> Bind<A, B>(this IUnion<A> a, Func<A, IUnion<B>> func)
		////{
		////	return func(a.Value);
		////}

		////public static IUnion<B> Select<A, B>(this IUnion<A> a, Func<A, IUnion<B>> select)
		////{
		////	return a.Bind(aval => select(aval));
		////}

		/// <summary>
		/// Matches the specified union.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="union">The union.</param>
		/// <returns></returns>
		public static bool Match<T>(this IUnion union)
		{
			var myUnion = union as IUnion<T>;
			if (myUnion == null)
			{
				return false;
			}

			return myUnion.HasValue;
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
			if (myUnion == null)
			{
				return false;
			}

			return myUnion.HasValue && condition(myUnion.Value);
		}

		public static T Value<T>(this IUnion union)
		{
			var myUnion = union as IUnion<T>;
			if (myUnion.HasValue)
			{
				return myUnion.Value;
			}

			throw new System.NullReferenceException("An Attempt was made to access unset union value");
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
		T Value { get; }

		bool HasValue { get; }
	}

	public class Union<T1> : IUnion, IUnion<T1>
	{
		private readonly T1 a;
		private readonly bool aHasValue;

		protected Union()
		{ }

		public Union(T1 a)
		{
			this.a = a;
			this.aHasValue = !IsValueNull(a);
		}

		T1 IUnion<T1>.Value
		{
			get
			{
				return a;
			}
		}

		bool IUnion<T1>.HasValue => this.aHasValue;

		protected bool IsValueNull<T>(T value)
		{
			var t = typeof(T);

			if (Nullable.GetUnderlyingType(t) != null)
			{
				return value == null;
			}
			if (t.IsValueType)
			{
				return false;
			}
			return value == null;
		}
	}

	public class Union<T1, T2> : Union<T1>, IUnion<T2>, IUnion
	{
		private readonly T2 b;
		private readonly bool bHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b)
		{
			this.b = b;
			this.bHasValue = !IsValueNull(b);
		}

		T2 IUnion<T2>.Value
		{
			get
			{
				return this.b;
			}
		}

		bool IUnion<T2>.HasValue => this.bHasValue;
	}

	public class Union<T1, T2, T3> : Union<T1, T2>, IUnion<T3>, IUnion
	{
		private readonly T3 c;
		private readonly bool cHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c)
		{
			this.cHasValue = !IsValueNull(c);
			this.c = c;
		}

		T3 IUnion<T3>.Value
		{
			get
			{
				return c;
			}
		}

		bool IUnion<T3>.HasValue => cHasValue;
	}

	public class Union<T1, T2, T3, T4> : Union<T1, T2, T3>, IUnion<T4>, IUnion
	{
		private readonly T4 d;
		private readonly bool dHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c) : base(c)
		{
		}

		public Union(T4 d)
		{
			this.dHasValue = !IsValueNull(d);
			this.d = d;
		}

		T4 IUnion<T4>.Value => d;

		bool IUnion<T4>.HasValue => dHasValue;
	}

	public class Union<T1, T2, T3, T4, T5> : Union<T1, T2, T3, T4>, IUnion<T5>, IUnion
	{
		private readonly T5 e;
		private readonly bool eHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c) : base(c)
		{
		}

		public Union(T4 d) : base(d)
		{
		}

		public Union(T5 e)
		{
			this.eHasValue = !IsValueNull(e);
			this.e = e;
		}

		T5 IUnion<T5>.Value => e;

		bool IUnion<T5>.HasValue => eHasValue;
	}

	public class Union<T1, T2, T3, T4, T5, T6> : Union<T1, T2, T3, T4, T5>, IUnion<T6>, IUnion
	{
		private readonly T6 f;
		private readonly bool fHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c) : base(c)
		{
		}

		public Union(T4 d) : base(d)
		{
		}

		public Union(T5 e) : base(e)
		{
		}

		public Union(T6 f)
		{
			this.fHasValue = !IsValueNull(f);
			this.f = f;
		}

		private T6 Item6 => f;

		T6 IUnion<T6>.Value
		{
			get
			{
				return f;
			}
		}

		bool IUnion<T6>.HasValue
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7> : Union<T1, T2, T3, T4, T5, T6>, IUnion<T7>, IUnion
	{
		private readonly T7 g;
		private readonly bool gHasValue;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c) : base(c)
		{
		}

		public Union(T4 d) : base(d)
		{
		}

		public Union(T5 e) : base(e)
		{
		}

		public Union(T6 f) : base(f)
		{
		}

		public Union(T7 g)
		{
			this.gHasValue = !IsValueNull(g);
			this.g = g;
		}

		T7 IUnion<T7>.Value
		{
			get
			{
				return g;
			}
		}

		bool IUnion<T7>.HasValue => gHasValue;
	}

	public class Union<T1, T2, T3, T4, T5, T6, T7, T8> : Union<T1, T2, T3, T4, T5, T6, T7>, IUnion<T8>, IUnion
	{
		private readonly T8 h;
		private readonly bool hHasValue;

		protected Union()
		{ }

		public Union(T2 b) : base(b)
		{
		}

		public Union(T3 c) : base(c)
		{
		}

		public Union(T4 d) : base(d)
		{
		}

		public Union(T5 e) : base(e)
		{
		}

		public Union(T6 f) : base(f)
		{
		}

		public Union(T7 g) : base(g)
		{
		}

		public Union(T8 h)
		{
			this.hHasValue = !IsValueNull(h);
			this.h = h;
		}

		T8 IUnion<T8>.Value
		{
			get
			{
				return h;
			}
		}

		bool IUnion<T8>.HasValue => hHasValue;
	}
}