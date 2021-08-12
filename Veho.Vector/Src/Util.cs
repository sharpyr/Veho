using System;

namespace Veho {
  public static partial class Util {
    public static T Swap<T>(this T[] vector, int i, int j) {
      var temp = vector[i];
      vector[i] = vector[j];
      return vector[j] = temp;
    }

    public static T[] Reverse<T>(this T[] arr) {
      Array.Reverse(arr);
      return arr;
    }

    public static void Resize<T>(this T[] vector, int len) => Array.Resize(ref vector, len);

    public static T[] ZeroOut<T>(this T[] vector) {
      var len = vector.Length;
      var target = new T[len];
      Array.Copy(vector, 1, target, 0, len);
      return target;
    }
  }
}