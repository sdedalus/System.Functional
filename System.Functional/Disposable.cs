using System;

namespace Functional
{
	public static class Disposable
	{
		public static TResult Using<TDisposible, TResult>(
			Func<TDisposible> factory,
			Func<TDisposible, TResult> map)
			where TDisposible : IDisposable
		{
			using (var disposable = factory())
			{
				return map(disposable);
			}
		}
	}
}