using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Functional.HigherOrderFunctions;

namespace HigherOrderFunctionTests
{
	[TestClass]
	public class OptionShould
	{
		[TestMethod]
		public void CreateAOptOfStringWhenGivenAString()
		{
			var x = "test".AsOption();

			Assert.IsInstanceOfType(x, typeof(Option<string>));

			Assert.IsTrue(x.IsSome());

			Assert.AreSame("test", x.Value());

			Assert.AreSame("test", x());
		}

		[TestMethod]
		public void ThrowsANullReferenceExceptionWhenTheRetreivedValueIsNull()
		{
			var x = ((string)null).AsOption();

			Assert.IsInstanceOfType(x, typeof(Option<string>));

			Assert.IsFalse(x.IsSome());

			Throws(() => x.Value(), typeof(NullReferenceException));

			Throws(() => x(), typeof(NullReferenceException));
		}

		[TestMethod]
		public void CreateASomeOptOfIntWhenGivenAInt()
		{
			var x = 1.AsOption();

			Assert.IsInstanceOfType(x, typeof(Option<int?>));

			Assert.IsTrue(x.IsSome());

			Assert.AreEqual(1, x.Value());

			Assert.AreEqual(1, x().Value);
		}

		[TestMethod]
		public void ThrowsANullReferenceExceptionWhenTheRetreivedIntValueIsNone()
		{
			var x = (null as int?).AsOption();

			Assert.IsInstanceOfType(x, typeof(Option<int?>));

			Assert.IsFalse(x.IsSome());

			Throws(() => x.Value(), typeof(NullReferenceException));

			Throws(() => x(), typeof(NullReferenceException));
		}

		[TestMethod]
		public void ThrowsAInvalidOperationExceptionWhenYouCreateAnOptionOfOption()
		{
			var x = 1.AsOption();

			Throws(() => x.AsOption(), typeof(InvalidOperationException));
		}

		private static void Throws(Action act, Type exceptionType)
		{
			try
			{
				act();
				Assert.Fail();
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex.GetType() == exceptionType);
			}
		}
	}
}