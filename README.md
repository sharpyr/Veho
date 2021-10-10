![DESIGN IMAGE](images/veho-logo.png?raw=true)

# Veho

[![NuGet](https://img.shields.io/nuget/vpre/Veho.svg)](https://www.nuget.org/packages/Veho)
[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/sharpyr)
[![GitHub license](https://img.shields.io/github/license/sharpyr/Veho.svg)](https://github.com/sharpyr/Veho/LICENSE.txt)

Veho, a .NET Standard array and enumerable extension library.

Veho is an extension library for iterable including array, 2d-array and dictionary, designed based on functional programming paradigm. Veho is currently availabe on npm.js for node.js, nuget.org as .NET standard package, crates.io for rust and pypi.org for python 3.

### SAMPLES

    Please see the Project Veho.Test in the solution.

### BASE USAGE

[Base usage Codes](https://github.com/sharpyr/Veho/blob/master/src/Veho.Sample/samples/BaseUsage.cs)

### EXAMPLE USAGE: Zip two arrays

[View complete Codes](https://github.com/sharpyr/Veho/blob/master/src/Veho.Sample/samples/EntitySpider.cs)

```c#
namespace Veho.Test.Vector {
  [TestFixture]
  public class ZipperTest {
    [Test]
    public void DuoZipperTest() {
      var a = new[] {1, 2, 3, 4, 5};
      var b = new[] {2, 2, 0, 3, 3};
      Func<int, int, int> fn = (x, y) => x * y;
      var vec = fn.Zipper(a, b);
      Console.WriteLine(string.Join(", ", vec));
    }
  }
}
```



