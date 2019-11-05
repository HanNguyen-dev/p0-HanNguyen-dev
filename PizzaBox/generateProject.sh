#!/bin/sh

dotnet new sln --name PizzaBox
dotnet new console --name PizzaBox.Client
dotnet new classlib --name PizzaBox.Domain
dotnet new classlib --name PizzaBox.Storing
dotnet new xunit --name PizzaBox.Testing

dotnet add PizzaBox.Client/PizzaBox.Client.csproj reference PizzaBox.Domain/PizzaBox.Domain.csproj
dotnet add PizzaBox.Domain/PizzaBox.Domain.csproj reference PizzaBox.Storing/PizzaBox.Storing.csproj

dotnet add PizzaBox.Testing/PizzaBox.Testing.csproj package coverlet.msbuild
dotnet add PizzaBox.Testing/PizzaBox.Testing.csproj package moq

mkdir PizzaBox.Domain/Abstracts
mkdir PizzaBox.Domain/Models
mkdir PizzaBox.Domain/Interfaces
mkdir PizzaBox.Storing/Repositories
mkdir PizzaBox.Testing/Mocks
mkdir PizzaBox.Testing/Specs

dotnet sln add **/*.csproj
