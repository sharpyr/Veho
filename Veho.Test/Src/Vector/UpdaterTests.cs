﻿using NUnit.Framework;
using Spare;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class UpdaterTests {
    [Test]
    public void PushTest() {
      var arr = Vec.From("a", "b", "c");
      arr.Push("d").Deco().Logger();
    }
    [Test]
    public void UnshiftTest() {
      var arr = Vec.From("a", "b", "c");
      arr.Unshift("-").Deco().Logger();
    }
    [Test]
    public void AcquireTest() {
      var arr = Vec.From("a", "b", "c");
      var another = Vec.From("x", "y", "z");
      arr.Acquire(another).Deco().Logger();
    }
    [Test]
    public void MergeTest() {
      var arr = Vec.From("a", "b", "c");
      var another = Vec.From("x", "y", "z");
      arr.Merge(another).Deco().Logger();
    }
  }
}