﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spare;
using Veho.Core.Vector;

namespace Veho.Test.FS {
  [TestFixture]
  public class SimpleTest {
    public void TestAlpha() {
      var list = new List<int>();
      Mappers.Utils.Abc(list).Logger();
      // var hasAny = list.HasAny;
      // var text = "foo-bar";
      // var textOut = text.Right(3);
      // Console.WriteLine(text.Right(3));
    }
  }
}