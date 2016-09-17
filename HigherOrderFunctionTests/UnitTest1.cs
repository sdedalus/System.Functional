﻿namespace HigherOrderFunctionTests
{
	using Functional;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using static Functional.HigherOrderFunctions;

	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void ReturnsAUnionOfStringErrorTypeWithAnErrorObject()
		{
			var test = Union.ToErrorUnion<string, DivideByZeroException>(TestError);

			Assert.IsTrue(test.Match<DivideByZeroException>().IsSome());
			Assert.IsFalse(test.Match<DivideByZeroException>().IsNone());

			Assert.IsFalse(test.Match<string>().IsSome());
			Assert.IsTrue(test.Match<string>().IsNone());
		}

		[TestMethod]
		public void ReturnsAUnionOfStringErrorTypeWithAString()
		{
			var test = Union.ToErrorUnion<string, DivideByZeroException>(Teststring);

			Assert.IsTrue(test.Match<string>().IsSome());
			Assert.IsFalse(test.Match<string>().IsNone());

			Assert.IsFalse(test.Match<DivideByZeroException>().IsSome());
			Assert.IsTrue(test.Match<DivideByZeroException>().IsNone());
		}

		private static string Teststring()
		{
			return "This is a test.";
		}

		private static string TestError()
		{
			throw new DivideByZeroException();
		}
	}
}