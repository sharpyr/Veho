using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Enumerable {
  public static partial class Tuples {
    public static (T, T) Dualet<T>(this IEnumerable<T> items, T def = default) {
      using (var f = items.GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def, f.MoveNext() ? f.Current : def);
      }
    }
    public static (T, T, T) Triplet<T>(this IEnumerable<T> items, T def = default) {
      using (var f = items.GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def);
      }
    }
    public static (T, T, T, T) Quadlet<T>(this IEnumerable<T> items, T def = default) {
      using (var f = items.GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def);
      }
    }
    public static (TO, TO) Dualet<T, TO>(this IEnumerable<T> items, Func<T, TO> func, TO def = default) {
      using (var cs = items.GetEnumerator()) {
        return (cs.MoveNext() ? func(cs.Current) : def, cs.MoveNext() ? func(cs.Current) : def);
      }
    }
  }

  public static partial class Tuples {
    public static (T, T) Dualet<T>(this IEnumerable items, T def = default) {
      using (var f = items.OfType<T>().GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def, f.MoveNext() ? f.Current : def);
      }
    }
    public static (T, T, T) Triplet<T>(this IEnumerable items, T def = default) {
      using (var f = items.OfType<T>().GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def);
      }
    }
    public static (T, T, T, T) Quadlet<T>(this IEnumerable items, T def = default) {
      using (var f = items.OfType<T>().GetEnumerator()) {
        return (f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def,
                f.MoveNext() ? f.Current : def);
      }
    }
    public static (TO, TO) Dualet<T, TO>(this IEnumerable items, Func<T, TO> func, TO def = default) {
      using (var cs = items.OfType<T>().GetEnumerator()) {
        return (cs.MoveNext() ? func(cs.Current) : def, cs.MoveNext() ? func(cs.Current) : def);
      }
    }
  }
}