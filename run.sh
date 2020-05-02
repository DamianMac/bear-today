#!/usr/bin/env bash

pushd src/BearToday
dotnet clean
dotnet publish -r osx-x64 /p:PublishSingleFile=true
popd
./src/BearToday/bin/Debug/netcoreapp3.1/osx-x64/publish/BearToday