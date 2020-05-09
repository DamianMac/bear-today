#!/usr/bin/env bash

pushd src/BearToday
dotnet clean
dotnet build -c Release
dotnet publish -c Release -r osx-x64 /p:PublishSingleFile=true
popd
cp ./src/BearToday/bin/Release/netcoreapp3.1/osx-x64/publish/BearToday ~/