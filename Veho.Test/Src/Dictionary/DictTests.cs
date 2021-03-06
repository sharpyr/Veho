﻿using System.Linq;
using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Dictionary;

namespace Veho.Test.Dictionary {
  [TestFixture]
  public class DictTests {
    [Test]
    public void DictInitTest() {
      var dict = Dict.From(
        ("foo", 1),
        ("bar", 2),
        ("zen", 3)
      );
      dict.ToString().Logger();
      dict.ToArray().Deco().Logger();
    }
  }
}