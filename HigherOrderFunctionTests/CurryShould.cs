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
			var a1 = HigherOrderFunctions.Curry<string, int, bool>(TestArityTwo);
			Assert.IsInstanceOfType(a1, typeof(Func<string, Func<int, bool>>));
			Assert.IsTrue(a1("")(1));
		}

		[TestMethod]
		public void ForArityThreeReturnAFuncOfFuncEtc()
		{
			var a1 = HigherOrderFunctions.Curry<string, int, bool, bool>(TestArityThree);
			Assert.IsInstanceOfType(a1, typeof(Func<string, Func<int, Func<bool, bool>>>));
			Assert.IsTrue(a1("")(1)(true));
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
	}
}