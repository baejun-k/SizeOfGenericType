using System;
using System.Reflection.Emit;

namespace SizeOfGenericType {
	public static class Example {
		public static void SaySizeOfGeneric<T>()
		{
			var dm = new DynamicMethod("SizeOfType", typeof(int), new Type[] { });
			var il = dm.GetILGenerator();
			il.Emit(OpCodes.Sizeof, typeof(T));
			il.Emit(OpCodes.Ret);
			int size = (int)dm.Invoke(null, null);

			Console.WriteLine($"Generic<{typeof(T)}> size : {size}");
		}
	}

	public struct Test {
		int a, b, c;
	}

	class Program {
		static void Main(string[] args)
		{
			Example.SaySizeOfGeneric<Test>();
		}
	}
}
