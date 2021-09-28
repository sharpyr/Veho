namespace Veho.Types {
  public delegate void ActionByRef<T>(ref T x);

  public delegate void ActionByRef<T1, T2>(ref T1 x, ref T2 y);

  public delegate void ActionByRef<T1, T2, T3>(ref T1 x, ref T2 y, ref T3 z);

  public delegate void IndexedActionByRef<T>(ref T x, int idx);
}