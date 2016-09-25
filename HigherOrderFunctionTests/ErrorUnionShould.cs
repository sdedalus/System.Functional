//namespace HigherOrderFunctionTests
//{
//	using Functional;
//	using Microsoft.VisualStudio.TestTools.UnitTesting;
//	using System;
//	using static Functional.HigherOrderFunctions;

//	/// <summary>
//	/// Summary description for UnitTest1
//	/// </summary>
//	[TestClass]
//	public class ErrorUnionShould
//	{
//		[TestMethod]
//		public void ReturnAUnionOfStringErrorTypeWithAnErrorObject()
//		{
//			var test = Union.ToErrorUnion<string, DivideByZeroException>(TestError);

//			Assert.IsTrue(test.Match<DivideByZeroException>().IsSome());
//			Assert.IsFalse(test.Match<DivideByZeroException>().IsNone());

//			Assert.IsFalse(test.Match<string>().IsSome());
//			Assert.IsTrue(test.Match<string>().IsNone());
//		}

//		// ToDo: I need to decide what to do for this case.
//		//[TestMethod]
//		//public void ReturnAUnionOfStringErrorTypeWithAnErrorObject2()
//		//{
//		//	var test = Union.ToErrorUnion<string, SystemException>(TestError);

//		//	Assert.IsTrue(test.Match<DivideByZeroException>().IsSome());
//		//	Assert.IsFalse(test.Match<DivideByZeroException>().IsNone());

//		//	Assert.IsFalse(test.Match<string>().IsSome());
//		//	Assert.IsTrue(test.Match<string>().IsNone());
//		//}

//		[TestMethod]
//		public void ReturnAUnionOfStringErrorTypeWithAString()
//		{
//			var test = Union.ToErrorUnion<string, DivideByZeroException>(Teststring);

//			Assert.IsTrue(test.Match<string>().IsSome());
//			Assert.IsFalse(test.Match<string>().IsNone());

//			Assert.IsFalse(test.Match<DivideByZeroException>().IsSome());
//			Assert.IsTrue(test.Match<DivideByZeroException>().IsNone());
//		}

//		private static string Teststring()
//		{
//			return "This is a test.";
//		}

//		private static string TestError()
//		{
//			throw new DivideByZeroException();
//		}
//	}
//}