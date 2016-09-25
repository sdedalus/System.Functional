using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HigherOrderFunctionTests
{
	[TestClass]
	public class CurryShould
	{
		[TestMethod]
		public void ForArityTwoReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool> testFunc = TestArityTwo;
			var a2 = testFunc.Curry();
			Assert.IsInstanceOfType(a2, typeof(Func<string, Func<int, bool>>));
			Assert.IsTrue(a2("")(1));
		}

		[TestMethod]
		public void ForArityThreeReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, bool> testFunc = TestArityThree;
			var a3 = testFunc.Curry();
			Assert.IsInstanceOfType(a3, typeof(Func<string, Func<int, Func<bool, bool>>>));
			var another = a3("test");
			Assert.IsTrue(a3("")(1)(true));
		}

		[TestMethod]
		public void ForArityFourReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, double, bool> testFunc = TestArityFour;
			var a4 = testFunc.Curry();
			Assert.IsInstanceOfType(a4, typeof(Func<string, Func<int, Func<bool, Func<double, bool>>>>));
			Assert.IsTrue(a4("")(1)(true)(1.0));
		}

		[TestMethod]
		public void ForArityFiveReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, double, string, bool> testFunc = TestArityFive;
			var a5 = testFunc.Curry();
			Assert.IsInstanceOfType(a5, typeof(Func<string, Func<int, Func<bool, Func<double, Func<string, bool>>>>>));
			Assert.IsTrue(a5("")(1)(true)(1.0)(""));
		}

		[TestMethod]
		public void ForAritySixReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, double, string, int, bool> testFunc = TestAritySix;
			var a6 = testFunc.Curry();
			Assert.IsInstanceOfType(a6, typeof(Func<string, Func<int, Func<bool, Func<double, Func<string, Func<int, bool>>>>>>));
			Assert.IsTrue(a6("")(1)(true)(1.0)("")(1));
		}

		[TestMethod]
		public void ForAritySevenReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, double, string, int, bool, bool> testFunc = TestAritySeven;
			var a7 = testFunc.Curry();
			Assert.IsInstanceOfType(a7, typeof(Func<string, Func<int, Func<bool, Func<double, Func<string, Func<int, Func<bool, bool>>>>>>>));
			Assert.IsTrue(a7("")(1)(true)(1.0)("")(1)(true));
		}

		[TestMethod]
		public void ForArityEightReturnAFuncOfFuncEtc()
		{
			Func<string, int, bool, double, string, int, bool, double, bool> testFunc = TestArityEight;
			var a8 = testFunc.Curry();
			Assert.IsInstanceOfType(a8, typeof(Func<string, Func<int, Func<bool, Func<double, Func<string, Func<int, Func<bool, Func<double, bool>>>>>>>>));
			Assert.IsTrue(a8("")(1)(true)(1.0)("")(1)(true)(1.1));
		}

		private bool TestArityTwo(string a, int b)
		{
			return true;
		}

		private bool TestArityThree(string a, int b, bool c)
		{
			return true;
		}

		private bool TestArityFour(string a, int b, bool c, double d)
		{
			return true;
		}

		private bool TestArityFive(string a, int b, bool c, double d, string e)
		{
			return true;
		}

		private bool TestAritySix(string a, int b, bool c, double d, string e, int f)
		{
			return true;
		}

		private bool TestAritySeven(string a, int b, bool c, double d, string e, int f, bool g)
		{
			return true;
		}

		private bool TestArityEight(string a, int b, bool c, double d, string e, int f, bool g, double h)
		{
			return true;
		}
	}
}