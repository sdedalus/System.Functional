//using Functional;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;

//namespace HigherOrderFunctionTests
//{
//	[TestClass]
//	public class UnitTest1
//	{
//		private class PartNumber : Wrapper<string> {
//			public PartNumber(string v) : base(v)
//			{
//			}
//		}

//		[TestMethod]
//		public void TestMethod1()
//		{
//			int a = 10;
//			int? b = 20;
//			int? c = null;
//			string d = "test";
//			string e = null;

//			Assert.IsFalse(IsValueNull(a));
//			Assert.IsFalse(IsValueNull(b));
//			Assert.IsTrue(IsValueNull(c));
//			Assert.IsFalse(IsValueNull(d));
//			Assert.IsTrue(IsValueNull(e));
//		}

//		[TestMethod]
//		public void TestMetho2()
//		{
//			PartNumber X = new PartNumber("test");
//			string s = X;
//			Assert.AreEqual(s, X);
//		}

//		protected bool IsValueNull<T>(T value)
//		{
//			var t = typeof(T);

//			if (Nullable.GetUnderlyingType(t) != null)
//			{
//				return value == null;
//			}
//			if (t.IsValueType)
//			{
//				return false;
//			}
//			return value == null;
//		}
//	}
//}