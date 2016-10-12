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

## Test SubtractVAT

## Add to AppVeyor

appveyor.yml

```
version: 1.0.{build}
build_script:
- cmd: >-
    dotnet restore

    dotnet build
test_script:
- cmd: dotnet test

```

## Add to travis ci
.travis.yml

```
language: csharp
mono: none
dotnet: 1.0.0-preview2-003131
install:
  - dotnet restore
script:
  - dotnet build **/project.json
  - dotnet test

```