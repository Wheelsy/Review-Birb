# Reaview Birb

Reaview Birb is a local ML.NET console application that can discern whether a product or service review is positive or negative.

## Features

- Read and process reviews
- Learn from user interactions to improve accuracy

## Requirements

- Windows
- Dotnet 8 SDK
- Visual Studio

## Instructions

1. In Visual Studio or File Explorer, open the project directory.
2. Locate `MLModel1.training.cs`.
3. Change the `ModelPath` variable to the path of `MLModel1.mlnet` on your machine.
4. Locate `IO.cs`.
5. Update the `filePath` variable to the path of `yelp_labelled.txt` on your machine.
6. Open `MLModel1.mbconfig` in visual studio and in the data tab select yelp_labelled.txt file as your input data source.

## How to Run

- From the command line, navigate to the project folder and execute `dotnet run` to start the application.
- Alternatively, open the project in Visual Studio and hit the green play button.

## Developed by

Ely Hawkins

