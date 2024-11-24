![Banner](https://raw.githubusercontent.com/sharpyr/Veho/refs/heads/master/media/veho-banner.svg)

Extend enumerable and array functionalities

[![Version](https://img.shields.io/nuget/vpre/Veho.svg)](https://www.nuget.org/packages/Veho)
[![Downloads](https://img.shields.io/nuget/dt/Veho.svg)](https://www.nuget.org/packages/Veho)
[![Dependent Libraries](https://img.shields.io/librariesio/dependents/nuget/Veho.svg?label=dependent%20libraries)](https://libraries.io/nuget/Veho)
[![Language](https://img.shields.io/badge/language-C%23-blueviolet.svg)](https://dotnet.microsoft.com/learn/csharp)
[![Compatibility](https://img.shields.io/badge/compatibility-.NET%20Standard%202.0-blue.svg)]()
[![License](https://img.shields.io/github/license/sharpyr/Veho.svg)](https://github.com/sharpyr/Veho/LICENSE)

## Features

Veho is an extension lib for iterable e.g. array, 2d-array and dictionary.

## Content

| Package               | Content                                           |
|-----------------------|---------------------------------------------------|
| `Veho`                | The core library, including all Veho sub projects |
| `Veho.Dictionary`     | Extend IDictionary<TK, TV>                        |
| `Veho.Entries`        | Extend IReadOnlyList<(TK key, TV value)>          |
| `Veho.Enumerable`     | Extend IEnumerable<T>                             |
| `Veho.Linear`         | Perform basic linear algebra for matrix           |
| `Veho.Matrix`         | Extend T[,]                                       |
| `Veho.Mutable.Matrix` | Extend IReadOnlyList<IReadOnlyList<T>>            |
| `Veho.OneBase`        | Extend 1-based (offset) array T[,]                |
| `Veho.PanBase`        | Extend general (offset) array T[,]                |
| `Veho.Sequence`       | Extend IReadOnlyList<T> to List<T>                |
| `Veho.Tuple`          | Extend (T, T), (T, T, T), (T, T, T, T)            |
| `Veho.Types`          | Base types in Veho series                         |
| `Veho.Vector`         | Extend T[]                                        |

## Install

Veho targets .NET Standard 2.0, fits both .NET and .NET Framework.

Install [Veho package](https://www.nuget.org/packages/Veho) and sub packages.

NuGet Package Manager:

```powershell
Install-Package Veho
```

.NET CLI:

```shell
dotnet add package Veho
```

All versions can be found [on nuget](https://www.nuget.org/packages/Veho#versions-body-tab).

## Usage

### Zip two arrays into an new array

```csharp
using Veho.Vector

var vecA = new[] {1, 2, 3, 4, 5};
var vecB = new[] {2, 2, 0, 3, 3};
Func<int, int, int> fn = (x, y) => x * y;
var vecC = fn.Zipper(vecA, vecB);
Console.WriteLine(string.Join(", ", vecC));
```

### Compute max by reducing an array

```csharp
using Veho.Vector;

var vec = Vec.From(1, 4, 6, 3, 2);
var max = vec.Reduce(Math.Max);
Console.WriteLine(max);
```

### Push a value into an array

```csharp
using Veho.Vector;
using Spare;

var arr = Vec.From("a", "b", "c");
arr.Push("d")
Console.WriteLine(arr.Deco())
```

>
# Examples
---------------------
Veho has a test suite in the [test project](https://github.com/sharpyr/Veho/tree/master/Veho.Test/Src).

## Feedback

Veho is licensed under the [MIT](https://github.com/sharpyr/Veho/LICENSE) license.

Bug report and contribution are welcome at [the GitHub repository](https://github.com/sharpyr/Veho).



