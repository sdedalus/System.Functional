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

			Assert.IsFalse(x.Match<string>(c => c != "test"));
			Assert.IsTrue(x.Match<string>(c => c == "test"));

			Assert.IsFalse(x.Match<int?>());
		}

		[TestMethod]
		public void ForUnionStringIntWhereStringIsSet()
		{
			var x = new Union<string, int?>("");

			Assert.IsTrue(x.Match<string>());
			Assert.IsFalse(x.Match<int?>());
		}

		[TestMethod]
		public void ForUnionStringIntWhereIntIsSet()
		{
			var x = new Union<string, int?>(1);

			Assert.IsTrue(x.Match<int?>());
			Assert.IsFalse(x.Match<string>());
		}

		[TestMethod]
		public void ForUnionStringIntWhereIntIsSetAndConditionsAreUsed()
		{
			var x = new Union<string, int>(1);

			Assert.IsTrue(x.Match<int>(c => c == 1));

			Assert.IsFalse(x.Match<string>());

			Assert.IsFalse(x.Match<int>(c => c == 10));
		}

		[TestMethod]
		public void ForUnionStringIntWhereIntIsSetAndLinqIsUsed()
		{
			var x = new Union<string, int>(1);

			var option1 = ((IUnion<string>)x).Select(c => c);
			var option2 = ((IUnion<int>)x).Select(c => c);
			Assert.IsTrue(option1.IsNone());

			Assert.IsTrue(((IUnion<string>)x).Where(c => c == "test").Select(c => c).IsNone());
			Assert.IsTrue(((IUnion<int>)x).Where(c => c == 10).Select(c => c).IsNone());
			Assert.IsTrue(((IUnion<int>)x).Where(c => c == 1).Select(c => c).IsSome());

			Assert.IsFalse(option2.IsNone());
		}

		[TestMethod]
		public void ForUnionStringNullableIntWhereIntIsSetAndConditionsAreUsed()
		{
			var x = new Union<string, int?>(1);

			Assert.IsTrue(x.Match<int?>(c => c == 1));

			Assert.IsFalse(x.Match<string>());

			Assert.IsFalse(x.Match<int?>(c => c == 10));
		}

		[TestMethod]
		public void PatternMatchingWithIntShouldHaveIntValue()
		{
			// Example Use allows pattern matching
			var input = new Union<string, int>(100);
			int output = 0;
			if (input.Match<int>())
			{
				output = input.Value<int>();
			}
			else if (input.Match<string>())
			{
				if (!int.TryParse(input.Value<string>(), out output))
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

			if (input.Match<int?>())
			{
				output = input.Value<int?>().Value;
			}

			if (input.Match<string>())
			{
				if (!int.TryParse(input.Value<string>(), out output))
				{
					output = 0;
				}
			}

			Assert.AreEqual(100, output);
		}
	}
}