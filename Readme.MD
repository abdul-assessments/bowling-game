# Introduction 
Welcome to the BowlingGame project. It is written in 2 parts. Angular for the FE and .Net Core for the BE.
BowlingGame.Web as the Api and my-app with-in the api project as the angular FE.

# Prerequisites
* [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.101-windows-x64-installer)
* [Angular 2](https://angular.io)


## Built Using
* Angular CLI
* Visual Studio 2019
* IIS / IISExpress

# Build and Test
1.	Clone the project and open in VS2019.
2.  You will need to run the .Net Core WebApi (BowlingGame.Web). (It can be in debug mode)
3.  The angular app requires an apiBaseUrl that you will need to change if required. This can be found in /my-app/src/environments/environment.ts
4.  The Angular app is located in /BowlingGame.Web/my-app/, however, the compiled scripts are referenced in the .Net Core app
6.	Drop a few breakpoints around the WebApi controller (BowlingController) and see how the system functions.
7.  There are tests. Currently implemented only for calculation logic.

## Disclaimer
Don't forget to read the instructions on how to play the game :)
