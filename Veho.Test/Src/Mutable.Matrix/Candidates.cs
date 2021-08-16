using System.Collections.Generic;

namespace Veho.Test.Mutable.Matrix {
  public static class Candidates {
    public static List<List<int>> FibonacciMatrix => Li.From(
      Li.From(1, 1, 2, 3, 5, 8),
      Li.From(13, 21, 34, 55, 89, 144),
      Li.From(233, 377, 610, 987, 1597, 2584),
      Li.From(4181, 6765, 10946, 17711, 28657, 46368)
    );
  }
}