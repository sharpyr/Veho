namespace Veho {
  public static partial class ToMatrix {
    public static T[,] ToRow<T>(this T[] vector) {
      var hi = vector.Length;
      var row = new T[1, hi];
      for (var j = 0; j < hi; j++) row[0, j] = vector[j];
      return row;
    }
    public static T[,] ToColumn<T>(this T[] vector) {
      var hi = vector.Length;
      var column = new T[hi, 1];
      for (var i = 0; i < hi; i++) column[i, 0] = vector[i];
      return column;
    }
  }
}