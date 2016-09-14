namespace Functional
{
	using System;

	public static partial class HigherOrderFunctions
	{
		public delegate T Option<T>(bool raise = true);

		public static Option<T?> AsOption<T>(this T value, T? ignored = default(T?)) where T : struct
		{
			var internalvalue = value as T?;

			if (internalvalue != null && value.GetType().Name == "Option`1")
			{
				throw new InvalidOperationException($"Can not create an Option of Option");
			}

			return (raise) =>
			{
				if (raise && internalvalue == null)
				{
					throw new NullReferenceException($"Option null of {typeof(T).Name}");
				}

				return internalvalue;
			};
		}

		public static Option<T?> AsOption<T>(this T? value)
		where T : struct
		{
			T? internalvalue = value;

			if (internalvalue != null && value.GetType().Name == "Option`1")
			{
				throw new InvalidOperationException($"Can not create an Option of Option");
			}

			return (raise) =>
			{
				if (raise && internalvalue == null)
				{
					throw new NullReferenceException($"Option null of {typeof(T).Name}");
				}

				return internalvalue;
			};
		}

		public class ClassConstraint<T> where T : class
		{ }

		public static Option<T> AsOption<T>(this T value, ClassConstraint<T> ignored = default(ClassConstraint<T>))
		where T : class
		{
			T internalvalue = value;

			if (value != null && value.GetType().Name == "Option`1")
			{
				throw new InvalidOperationException($"Can not create an Option of Option");
			}

			return (raise) =>
			{
				if (raise && internalvalue == null)
				{
					throw new NullReferenceException($"Option null of {typeof(T).Name}");
				}

				return internalvalue;
			};
		}

		public static Option<object> Some()
		{
			var internalvalue = new object();

			return (raise) =>
			{
				return internalvalue;
			};
		}

		public static Option<object> None()
		{
			return (raise) =>
			{
				if (raise)
				{
					throw new NullReferenceException($"Option None");
				}
				return null;
			};
		}

		/// <summary>
		/// Values the specified option.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns></returns>
		public static T Value<T>(this Option<T> option) where T : class => option();

		/// <summary>
		/// Values the specified option.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns></returns>
		public static T Value<T>(this Option<T?> option) where T : struct => option().Value;

		/// <summary>
		/// Determines whether this instance is some.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns>
		///   <c>true</c> if the specified option is some; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsSome<T>(this Option<T> option) where T : class => option(false) != null;

		/// <summary>
		/// Determines whether this instance is some.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns>
		///   <c>true</c> if the specified option is some; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsSome<T>(this Option<T?> option) where T : struct => option(false).HasValue;

		/// <summary>
		/// Determines whether this instance is none.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns>
		///   <c>true</c> if the specified option is none; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNone<T>(this Option<T> option) where T : class => option(false) == null;

		/// <summary>
		/// Determines whether this instance is none.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="option">The option.</param>
		/// <returns>
		///   <c>true</c> if the specified option is none; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNone<T>(this Option<T?> option) where T : struct => !option(false).HasValue;

		public static void IfNotNull<T>(this T value, Action act)
			where T : class
		{
			if (value != null)
			{
				act();
			}
		}
	}
}