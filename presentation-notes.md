# Presentation notes

Unit testing our latest intern T Rump's superduper VAT calculator
I have a feeling that he is FIRED


## XUnit.net

[https://xunit.github.io/](https://xunit.github.io/)

Unit testing framework for dotnet

* Works with pretty much any flavor of [dotnet](https://xunit.github.io/#runners)
* Integrates with pretty much all test runners
* Open source under the umbrella of the .NET Foundation
* Seems to be Microsoft's preferred tool (MSTest boo)
* A bunch of built in assertions [comparison doc](https://xunit.github.io/docs/comparisons.html)

## Prereqs

Install dotnet core [https://www.microsoft.com/net/core#macos](https://www.microsoft.com/net/core#macos)
**Note:** PATH not set see here [https://github.com/dotnet/cli/issues/4225](https://github.com/dotnet/cli/issues/4225)

## Clone and run project

Run `dotnet restore` in the project root folder to restore all nuget packages in all projects.

Run `dotnet build **/project.json`to build all projects.

Navigete to `src/vatCalc` and run `dotnet run add 100 25` to run the cli program adding 25% vat to 100 kr. 

## Add xUnit.net project

* mkdir ./test/vatCalc.test
* dotnet new -t xunittest

* update to new xunit in `project.json`

    "xunit": "2.2.0-beta2-build3300",
    "dotnet-test-xunit": "2.2.0-preview2-build1029",
    "vatCalc.lib": "1.0.0"

## Run the unit tests 

navigate to the `test/vatCalc.test/` directory.

Run `dotnet test` to run xUnit's Dotnet Core runner. 

## Test AddVAT

Super simple tests just to show `[Fact]` in action.

Fact is used for traditional unit tests testing one thing once.
```

        [Fact]
        public void Adding_25_percent_VAT_to_100_is_125() 
        {
            Assert.Equal(125, VATCalculator.AddVAT(100, 25));
        }

        [Fact]
        public void Adding_20_percent_VAT_to_200_is_240() 
        {
            Assert.True(VATCalculator.AddVAT(200, 20) == 240);
        }

```
## Test SubtractVAT

Theory tests are really nice for encapsulating test code.

A more data driven way of writing tests.  

Many times you would either be copying code between tests or externalize it out into methods called from all tests.

They get rid of a lot of copied code and makes the test code more readable.

This is what the NUnit group was talking about with `TestCase`

```
        [Theory]
        [InlineData(100, 25, 80.0)]
        [InlineData(100, 20, "83.33333333333333333333333333")]
        public void Subtracting(decimal value, decimal percentage, decimal result)
        {
            Assert.Equal(result, VATCalculator.SubtractVAT(value, percentage));
        }
```

## Fix the code

T Rump's code was obviously wrong, so we fix it with a very simplistic fix.

```
        public static decimal SubtractVAT(decimal originalPrice, decimal vatPercentage)
        {    
            return (originalPrice / ( 100 + vatPercentage )) * 100;
        }
```

## CI Integration

Really easy, since it is all commandline and dotnet/nuget

Integrates into the dotnet commandline affording us the `dotnet test` command.

Works cross platform

### Add to AppVeyor

[https://www.appveyor.com/](https://www.appveyor.com/)

Really easy setup through `appveyor.yml`

Just need to go in and find the project in the [appveyor ci interface](https://ci.appveyor.com) in the project list from github. 

### Add to travis ci ( not working )

[https://travis-ci.org/](https://travis-ci.org/)

Haven't gotten it working but that is more of a dotnet core problem than a xunit.net problem. 

Not working configuration is in the `.travis.yml`

According to documentation the file included should work, but doesn't. 

## Conclusions

* Really simple to get started with.
* Documentation is a bit sparse
* Easy to integrate with CI servers since it is all command line.
* Cross platform
* Integrates with many runners in for example Visual Studio
    * ReSharper, CodeRush, TestDriven.NET and Xamarin according to the website.
* Test results can be output as xml for further analysis / display in CI server.
* Dotnet core integration is still beta and makes quite a few changes.
* Like NUnit way ahead of MSTest
* Integration with Visual Studio is dependent on third party tools.
* Still early days for Dotnet Core which is of course not xUnit's fault.