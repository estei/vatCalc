# Presentation notes

Unit testing our latest intern T Rump's superduper VAT calculator
I have a feeling that he is FIRED

## Prereqs

install dotnet core [https://www.microsoft.com/net/core#macos](https://www.microsoft.com/net/core#macos)
**Note:** PATH not set see here [https://github.com/dotnet/cli/issues/4225](https://github.com/dotnet/cli/issues/4225)

## Clone and run project
## Add xunit.net project

* mkdir ./test/vatCalc.test
* dotnet new -t xunittest

* update to new xunit

    "xunit": "2.2.0-beta2-build3300",
    "dotnet-test-xunit": "2.2.0-preview2-build1029",
    "vatCalc.lib": "1.0.0"

## Test AddVAT

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


```
        [Theory]
        [InlineData(100, 25, 80.0)]
        [InlineData(100, 20, "83.33333333333333333333333333")]
        public void Subtracting(decimal value, decimal percentage, decimal result)
        {
            Assert.Equal(result, VATCalculator.SubtractVAT(value, percentage));
        }
```

## Fix the test

```
        public static decimal SubtractVAT(decimal originalPrice, decimal vatPercentage)
        {    
            return (originalPrice / ( 100 + vatPercentage )) * 100;
        }
```

## Add to AppVeyor

## Add to travis ci ( not working )