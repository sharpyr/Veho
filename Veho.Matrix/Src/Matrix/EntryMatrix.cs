namespace Veho.Matrix {
  public static class EntryMatrix {
    public static (TK[,], TV[,]) Unwind<TK, TV>(this (TK key, TV item)[,] entryMatrix) {
      var (h, w) = entryMatrix.Size();
      var keys = new TK[h, w];
      var values = new TV[h, w];
      entryMatrix.Iterate((i, j, entry) => {
        keys[i, j] = entry.key;
        values[i, j] = entry.item;
      });
      return (keys, values);
    }
  }
}