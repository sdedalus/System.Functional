using System;

//
namespace Functional
{
	public class Option<T>
	{
		public static implicit operator T(Option<T> d)
		{
			return ((Some<T>)d).Value;
		}
	}

	public class None<T> : Option<T>
	{
		public override string ToString()
		{
			return "Nothing";
		}
	}

	public class Some<T> : Option<T>
	{
		public T Value { get; private set; }

		public Some(T value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}

	public static class Option
	{
		public static bool IsSome<T>(this Option<T> value)
		{
			if (value == null)
			{
				return false;
			}

			return value.GetType() != typeof(None<T>);
		}

		public static bool IsNone<T>(this Option<T> value)
		{
			if (value == null)
			{
				return true;
			}

			return value.GetType() == typeof(None<T>);
		}

		public static Option<T> ToMaybe<T>(this T value)
		{
			return new Some<T>(value);
		}

		public static Option<B> Bind<A, B>(this Option<A> a, Func<A, Option<B>> func)
		{
			var justa = a as Some<A>;
			return justa == null ?
				new None<B>() :
				func(justa.Value);
		}

		public static Option<C> SelectMany<A, B, C>(this Option<A> a, Func<A, Option<B>> func, Func<A, B, C> select)
		{
			return a.Bind(aval =>
				func(aval).Bind(bval =>
				select(aval, bval).ToMaybe()));
		}

		public static Option<B> Select<A, B>(this Option<A> a, Func<A, Option<B>> select)
		{
			return a.Bind(aval => select(aval));
		}
	}
}