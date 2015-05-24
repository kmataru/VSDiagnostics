# VSDiagnostics
A collection of code-quality analyzers based on the new Roslyn platform. This project aims to ensure code-quality as you type it in your editor rather than having to do this as a separate build-step. Likewise it also tries to help avoid some common pitfalls.

<img src="https://cloud.githubusercontent.com/assets/2777107/7789534/a06db792-0264-11e5-955f-11cbf3261d4f.gif" />

[Get it from NuGet!](https://www.nuget.org/packages/VSDiagnostics/)

## What is an analyzer exactly?

> With the release of Visual Studio 2015 RC, we also received the pretty much final implementation of the Diagnostics implementation. This SDK allows us to create our own diagnostics to help us write proper code that’s being verified against those rules in real-time: you don’t have to perform the verification at a separate build-step. What’s more is that we can combine that with a code fix: a shortcut integrated in Visual Studio that provides us a solution to what we determine to be a problem.

> This might sound a little abstract but if you’ve been using Visual Studio (and/or Resharper) then you know what I mean: have you ever written your classname as class rather than Class? This is a violation of the C# naming conventions and visual studio will warn you about it and provide you a quickfix to turn it into a proper capitalized word. This is exactly the behaviour we can create and which is integrated seemlessly in Visual Studio.

Full text available on [my blog](http://www.vannevel.net/2015/05/03/getting-started-with-your-first-diagnostic/).

## What is available?

Currently these diagnostics are implemented:

| Category | Name | Description | Analyzer | Code Fix |
|:-:|:-:|:-:|:-:|:-:|
| Exceptions | EmptyArgumentException | Guards against using an `ArgumentException` without specifying which argument. | Yes  | No  |
| Exceptions   | SingleGeneralException  | Guards against using a catch-all clause.  | Yes  | No   |
| Exceptions  | CatchNullReferenceException  | Guards against catching a NullReferenceException  | Yes   | No   |
| Exceptions | ArgumentExceptionWithNameofOperator | `ArgumentException` and its subclasses should use `nameof()` when they refer to a method parameter. | Yes | Yes |
| Async | AsyncMethodWithoutAsyncSuffix | Asynchronous methods should end with -Async | Yes | Yes |
| Strings | ReplaceEmptyStringWithStringDotEmpty | Use `string.Empty` instead of `""`. | Yes | Yes |
| Tests | TestMethodWithoutPublicModifier | Change the access modifier to `public` for all methods annotated as test. Supports NUnit, MSTest and xUnit.net. | Yes | Yes |
| General | NullableToShorthand | Changes `Nullable<T>` to `T?` | Yes | Yes |
| General | IfStatementWithoutBraces | Changes one-liner `if` and `else` statements to be surrounded in a block. | Yes | Yes |

## How do I use this?

We will release it as a NuGet package and as a Visual Studio extension once we believe there is a sufficient amount of analyzers. If you can't wait for this you can always fork the project and run it yourself locally.

## Can I request analyzers?

Yes, you can! Create an issue and we'll take a look at your proposal. 

## Can I contribute?

Definitely! Take a look at the open issues and see if there's anything that interests you. Submit your pull request and we'll take a look at it as soon as possible.

If you think you're going to make larger changes than a single implementation then we would ask you to get in contact with us first so we can discuss it and prevent unneeded work. 
