#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/.."
dotnet publish AveniqMvc.csproj -c Release -r linux-x64 --self-contained true -o ./publish/linux-x64
