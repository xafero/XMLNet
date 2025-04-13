#!/bin/sh

dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained false src/XMLCmd -o pub
dotnet publish -c Release -r win-x64   -p:PublishSingleFile=true --self-contained false src/XMLCmd -o pub

