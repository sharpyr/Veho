namespace Veho.Factory {
  public static partial class OperatorFactory {
    // public static Func<T, T, T> ParseElementOperator<T>(Func<T, T, T> func) {
    //   // typeof(T).GetElementType();
    //   return typeof(T).IsArray ? MakeArrayOperator(func) : func;
    // }
    // public static Func<T, T, T> MakeArrayOperator<T>(Func<T, T, T> func) {
    //   return (dynamic x, dynamic y) => ZipperSpace.Op<dynamic>((IReadOnlyList<dynamic>)x, (IReadOnlyList<dynamic>)y, func);
    // }
  }
}