using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static Functional.Option;

namespace HigherOrderFunctionTests
{
	[TestClass]
	public class OptionShould
	{
		[TestMethod]
		public void Testone()
		{
			var someValue = "Test".ToMaybe();
			Assert.IsInstanceOfType(someValue, typeof(Some<string>));

			string x = someValue;

			Assert.AreEqual("Test", x);
		}

		[TestMethod]
		public void TestTwo()
		{
			var opt = "Test".ToMaybe();
			Assert.IsTrue(opt.IsSome());
		}

		[TestMethod]
		public void CreateAOptOfStringWhenGivenAString()
		{
			var x = "test".ToMaybe();

			Assert.IsInstanceOfType(x, typeof(Option<string>));

			Assert.IsTrue(x.IsSome());

			Assert.AreSame("test", (string)x);
		}

		[TestMethod]
		public void ThrowsANullReferenceExceptionWhenTheRetreivedValueIsNull()
		{
			var x = new None<string>();

			//var y = new List<string>();
			string a;

			Throws(() => a = from z in x select z.ToMaybe(), typeof(InvalidCastException));

			Throws(() => a = x.Select(v => v.ToMaybe()), typeof(InvalidCastException));

			//var temp = from v in x where IsSome select v;
			//Assert.IsInstanceOfType(x, typeof(Option<string>));

			Assert.IsFalse(x.IsSome());

			//Throws(() => x.Value, typeof(NullReferenceException));

			//Throws(() => x(), typeof(NullReferenceException));
		}

		//[TestMethod]
		//public void CreateASomeOptOfIntWhenGivenAInt()
		//{
		//	var x = 1.AsOption();

		//	Assert.IsInstanceOfType(x, typeof(Option<int?>));

		//	Assert.IsTrue(x.IsSome());

		//	Assert.AreEqual(1, x.Value());

		//	Assert.AreEqual(1, x().Value);
		//}

		//[TestMethod]
		//public void ThrowsANullReferenceExceptionWhenTheRetreivedIntValueIsNone()
		//{
		//	var x = (null as int?).AsOption();

		//	Assert.IsInstanceOfType(x, typeof(Option<int?>));

		//	Assert.IsFalse(x.IsSome());

		//	Throws(() => x.Value(), typeof(NullReferenceException));

		//	Throws(() => x(), typeof(NullReferenceException));
		//}

		//[TestMethod]
		//public void ThrowsAInvalidOperationExceptionWhenYouCreateAnOptionOfOption()
		//{
		//	var x = 1.AsOption();

		//	Throws(() => x.AsOption(), typeof(InvalidOperationException));
		//}

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