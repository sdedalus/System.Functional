using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Functional.HigherOrderFunctions;

namespace HigherOrderFunctionTests
{
	[TestClass]
	public class Memoizeshould
	{
		[TestMethod]
		public void MemoizeArityTwoFunction()
		{
			var mem = Memoize<string, int, bool>(TestArityTwo);
			testArityTwo = true;
			Assert.IsTrue(mem("", 1));
			testArityTwo = false;
			Assert.IsTrue(mem("", 1));
		}

		[TestMethod]
		public void MemoizeArityThreeFunction()
		{
			var mem = Memoize<string, int, bool, bool>(TestArityThree);
			testArityThree = true;
			Assert.IsTrue(mem("", 1, true));
			testArityThree = false;
			Assert.IsTrue(mem("", 1, true));
		}

		[TestMethod]
		public void MemoizeArityFourFunction()
		{
			var mem = Memoize<string, int, bool, double, bool>(TestArityFour);
			testArityFour = true;
			Assert.IsTrue(mem("", 1, true, 1.1));
			testArityFour = false;
			Assert.IsTrue(mem("", 1, true, 1.1));
		}

		[TestMethod]
		public void MemoizeArityFiveFunction()
		{
			var mem = Memoize<string, int, bool, double, string, bool>(TestArityFive);
			testArityFive = true;
			Assert.IsTrue(mem("", 1, true, 1.1, ""));
			testArityFive = false;
			Assert.IsTrue(mem("", 1, true, 1.1, ""));
		}

		[TestMethod]
		public void MemoizeAritySixFunction()
		{
			var mem = Memoize<string, int, bool, double, string, int, bool>(TestAritySix);
			testAritySix = true;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1));
			testAritySix = false;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1));
		}

		[TestMethod]
		public void MemoizeAritySevenFunction()
		{
			var mem = Memoize<string, int, bool, double, string, int, bool, bool>(TestAritySeven);
			testAritySeven = true;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1, true));
			testAritySeven = false;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1, true));
		}

		[TestMethod]
		public void MemoizeArityEightFunction()
		{
			var mem = Memoize<string, int, bool, double, string, int, bool, double, bool>(TestArityEight);
			testArityEight = true;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1, true, 1.1));
			testArityEight = false;
			Assert.IsTrue(mem("", 1, true, 1.1, "", 1, true, 1.1));
		}

		private bool testArityTwo;

		private bool TestArityTwo(string a, int b)
		{
			return testArityTwo;
		}

		private bool testArityThree;

		private bool TestArityThree(string a, int b, bool c)
		{
			return testArityThree;
		}

		private bool testArityFour;

		private bool TestArityFour(string a, int b, bool c, double d)
		{
			return testArityFour;
		}

		private bool testArityFive;

		private bool TestArityFive(string a, int b, bool c, double d, string e)
		{
			return testArityFive;
		}

		private bool testAritySix;

		private bool TestAritySix(string a, int b, bool c, double d, string e, int f)
		{
			return testAritySix;
		}

		private bool testAritySeven;

		private bool TestAritySeven(string a, int b, bool c, double d, string e, int f, bool g)
		{
			return testAritySeven;
		}

		private bool testArityEight;

		private bool TestArityEight(string a, int b, bool c, double d, string e, int f, bool g, double h)
		{
			return testArityEight;
		}
	}
}