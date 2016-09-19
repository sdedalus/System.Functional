using Functional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Functional.HigherOrderFunctions;

namespace HigherOrderFunctionTests
{
	[TestClass]
	public class UnionShould
	{
		[TestMethod]
		public void ForUnionStringIntWhereStringIsSetAndConditionsAreUsed()
		{
			var x = new Union<string, int?>("test");

			Assert.IsFalse(x.Match<string>(c => c != "test").IsSome());
			Assert.IsTrue(x.Match<string>(c => c != "test").IsNone());

			Assert.IsTrue(x.Match<string>(c => c == "test").IsSome());
			Assert.IsFalse(x.Match<string>(c => c == "test").IsNone());

			Assert.IsTrue(x.Match<int>().IsNone());
			Assert.IsFalse(x.Match<int>().IsSome());
		}

		[TestMethod]
		public void ForUnionStringIntWhereStringIsSet()
		{
			var x = new Union<string, int?>("");

			Assert.IsTrue(x.Match<string>().IsSome());
			Assert.IsFalse(x.Match<string>().IsNone());

			Assert.IsTrue(x.Match<int>().IsNone());
			Assert.IsFalse(x.Match<int>().IsSome());
		}

		[TestMethod]
		public void ForUnionStringIntWhereIntIsSet()
		{
			var x = new Union<string, int?>(1);

			Assert.IsTrue(x.Match<int>().IsSome());
			Assert.IsFalse(x.Match<int>().IsNone());

			Assert.IsTrue(x.Match<string>().IsNone());
			Assert.IsFalse(x.Match<string>().IsSome());
		}

		[TestMethod]
		public void ForUnionStringIntWhereIntIsSetAndConditionsAreUsed()
		{
			var x = new Union<string, int?>(1);

			Assert.IsTrue(x.Match<int>(c => c == 1).IsSome());
			Assert.IsFalse(x.Match<int>(c => c == 1).IsNone());

			Assert.IsTrue(x.Match<string>().IsNone());
			Assert.IsFalse(x.Match<string>().IsSome());

			Assert.IsFalse(x.Match<int>(c => c == 10).IsSome());
			Assert.IsTrue(x.Match<int>(c => c == 10).IsNone());
		}

		[TestMethod]
		public void PatternMatchingWithIntShouldHaveIntValue()
		{
			// Example Use allows pattern matching
			var input = new Union<string, int?>(100);
			int output = 0;
			if (input.Match<int>().IsSome())
			{
				output = input.Match<int>().Value();
			}
			else if (input.Match<string>().IsSome())
			{
				if (!int.TryParse(input.Match<string>().Value(), out output))
				{
					output = 0;
				}
			}

			Assert.AreEqual(100, output);
		}

		[TestMethod]
		public void PatternMatchingWithStringShouldHaveStringValue()
		{
			// Example Use allows pattern matching
			var input = new Union<string, int?>("100");
			int output = 0;

			if (input.Match<int>().IsSome())
			{
				output = input.Match<int>().Value();
			}

			if (input.Match<string>().IsSome())
			{
				if (!int.TryParse(input.Match<string>().Value(), out output))
				{
					output = 0;
				}
			}

			Assert.AreEqual(100, output);
		}
	}
}