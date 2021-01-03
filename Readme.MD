# Introduction 
Welcome to the BowlingGame project. It is written in 2 parts. Angular for the FE and .Net Core for the BE.

# Prerequisites
* [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.101-windows-x64-installer)
* [Angular 2](https://angular.io)


## Built Using
* Angular CLI
* Visual Studio 2019
* IIS / IISExpress

# Build and Test
1.	Clone the project and open in VS2019. There are 2 apps that run seperately. 
2.  You will need to run the .Net Core WebApi (BowlingGame.Web) first. (It can be in debug mode)
3.  The angular app requires an apiBaseUrl that you will need to change if required. This can be found in /my-app/src/environments/environment.ts
4.  To run the Angular app, simply right click the my-app folder and select Open in Terminal (unfortunately you will need to restore all the packages), make sure to select Command Prompt, then run ng s --o from /BowlingGame.Web/my-app/
6.	Drop a few breakpoints around the WebApi controller (BowlingController) and see how the system functions.
7.  There are tests. Currently implemented only for calculation logic.

## Disclaimer
Don't forget to read the instructions on how to play the game :)