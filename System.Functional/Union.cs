using static Functional.HigherOrderFunctions;

namespace System.Functional
{
	public static class Union
	{
		public static Option<T> Match<T>(this IUnion union, ClassConstraint<T> ignored = default(ClassConstraint<T>)) where T : class
		{
			var myUnion = union as IUnion<T>;
			var value = myUnion.value;
			return value.AsOption();
		}

		public static Option<T?> Match<T>(this IUnion union, T? ignored = default(T?))
			where T : struct
		{
			var myUnion = union as IUnion<T>;
			if (myUnion != null)
			{
				var value = myUnion.value;
				return value.AsOption();
			}

			var nullableUnion = union as IUnion<T?>;

			var nullableValue = nullableUnion.value;
			return nullableValue.AsOption();
		}
	}

	public interface IUnion
	{
	}

	public interface IUnion<T>
	{
		T value { get; }
	}

	public class Union<T1> : IUnion, IUnion<T1>
	{
		private readonly T1 a;

		protected Union()
		{ }

		public Union(T1 a)
		{
			OptionGuard(a);
			this.a = a;
		}

		internal T1 Item1 => a;

		T1 IUnion<T1>.value
		{
			get
			{
				return Item1;
			}
		}

		protected void OptionGuard<T>(T value)
		{
			if (value != null && value.GetType().Name == "Option`1")
			{
				throw new InvalidOperationException($"Can not create an Union of Options");
			}
		}
	}

	public class Union<T1, T2> : Union<T1>, IUnion<T2>
	{
		private readonly T1 a;
		private readonly T2 b;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b)
		{
			OptionGuard(b);
			this.b = b;
		}

		public T2 Item2 => b;

		T2 IUnion<T2>.value
		{
			get
			{
				return Item2;
			}
		}
	}

	public class Union<T1, T2, T3> : Union<T1, T2>, IUnion<T3>
	{
		private readonly T3 c;

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
			OptionGuard(c);
			this.c = c;
		}

		internal T3 Item3 => c;

		T3 IUnion<T3>.value
		{
			get
			{
				return Item3;
			}
		}
	}

	public class Union<T1, T2, T3, T4> : Union<T1, T2, T3>, IUnion<T4>
	{
		private readonly T4 d;

		protected Union()
		{ }

		public Union(T1 a) : base(a)
		{
		}

		public Union(T2 b) : base(b)
		{
		}

		public Union(T4 d)
		{
			OptionGuard(d);
			this.d = d;
		}

		internal T4 Item4 => d;

		T4 IUnion<T4>.value
		{
			get
			{
				return Item4;
			}
		}
	}

	public class Union<T1, T2, T3, T4, T5> : Union<T1, T2, T3, T4>, IUnion<T5>
	{
		private readonly T5 e;

		protected Union()
		{ }

		public Union(T5 e)
		{
			OptionGuard(e);
			this.e = e;
		}

		private T5 Item5 => e;

		public T5 value
		{
			get
			{
				return Item5;
			}
		}
	}
}