using System;

namespace Veho.Vector {
  public static class Updaters {
    public static T[] Push<T>(this T[] vector, T element) {
      var hi = vector.Length;
      var len = hi + 1;
      Array.Resize(ref vector, len);
      vector[hi] = element;
      return vector;
    }
    
    
    

  }
}