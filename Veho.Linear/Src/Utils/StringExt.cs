using Veho.Formula;

namespace Veho.Utils {
  public static class StringExt {
    public static T Concatenate<T>(T a, T b) => Algebra.Convert<string, T>(a.ToString() + b.ToString());
  }
}