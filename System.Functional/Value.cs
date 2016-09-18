namespace Functional
{
	//public abstract class Value<T>
	//   where T : Value<T>
	//{
	//	public override bool Equals(object obj)
	//	{
	//		var valueObject = obj as T;

	//		if (ReferenceEquals(valueObject, null))
	//			return false;

	//		return EqualsCore(valueObject);
	//	}

	//	protected abstract bool EqualsCore(T other);

	//	public override int GetHashCode()
	//	{
	//		return GetHashCodeCore();
	//	}

	//	protected abstract int GetHashCodeCore();

	//	public static bool operator ==(Value<T> a, Value<T> b)
	//	{
	//		if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
	//			return true;

	//		if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
	//			return false;

	//		return a.Equals(b);
	//	}

	//	public static bool operator !=(Value<T> a, Value<T> b)
	//	{
	//		return !(a == b);
	//	}
	//}
}