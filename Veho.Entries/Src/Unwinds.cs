namespace Veho {
  public static partial class Entries {
    public static (TK[], TV[]) Unwind<TK, TV>(this (TK, TV)[] entries) {
      var len = entries.Length;
      var keys = new TK[len];
      var values = new TV[len];
      for (var i = 0; i < len; i++) {
        var (k, v) = entries[i];
        keys[i] = k;
        values[i] = v;
      }
      return (keys, values);
    }
  }
}