# Bowling Score Generator

This console application generates bowling scores according to the [USBC scoring guidelines](http://usbcongress.http.internapcdn.net/usbcongress/bowl/rules/pdfs/ScoreHowto.pdf).

## How to Run

Once the application has been build (see [How to Build](#how-to-build)), the application can be ran by passing a command-line argument path to a score JSON file. Below is an example of running of the development samples:

```csharp
cd .\src\Bowling.App\
dotnet build
dotnet run ..\..\samples\sample.json
```

The application expects a JSON-formatted file with an array of Frame objects. Each frame contains an ID and up to three optional deliveries

```JSON
{
  "id": 1,
  "delivery1": "F",
  "delivery2": "/",
  "delivery3": "9"
}
```

> Note: Standard USBC nomenclature can be used, with the exception of split characters (e.g. `s8`). Additionally, a strike on a frame is noted by an "X" in `delivery2` with no additional deliveries - except for the 10th frame.

## How to Build

To build the application, navigate to the `src` directory and execute the `dotnet build` command.

```csharp
cd src
dotnet restore
dotnet build
```

## How to Test

This application contains a unit test file for the Frame model. To test, use the following commands:

```csharp
cd src
dotnet test
```
