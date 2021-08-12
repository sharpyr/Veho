namespace Veho {
  public static partial class Entries {
    public static (TK, TV)[] Wind<TK, TV>(TK[] keys, TV[] values) {
      var hi = keys.Length;
      var entries = new (TK, TV)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (keys[lo], values[lo]);
      return entries;
    }
  }
}