using System;

namespace Veho.Vector {
  public static class Util {
    public static T Swap<T>(this T[] vec, int i, int j) {
      var temp = vec[i];
      vec[i] = vec[j];
      return vec[j] = temp;
    }

    public static T[] Reverse<T>(this T[] vec) {
      Array.Reverse(vec);
      return vec;
    }

    public static void Resize<T>(this T[] vec, int len) => Array.Resize(ref vec, len);

    [Obsolete("Use Rebase")]
    public static T[] ZeroOut<T>(this T[] vec) {
      var len = vec.Length;
      var target = new T[len];
      Array.Copy(vec, 1, target, 0, len);
      return target;
    }
  }
}