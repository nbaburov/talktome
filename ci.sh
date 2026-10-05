#!/usr/bin/env bash
# Showcase CI: what "builds and runs from a clean checkout" means for this repository.
# Called by the shared workflow in nbaburov/.github; run it locally with `bash ci.sh`.
# Every check runs in a pinned container, so the result does not depend on the machine.
set -euo pipefail
cd "$(dirname "$0")"

# The admin app is Windows Forms; EnableWindowsTargeting lets it build on Linux.
docker run --rm -v "$PWD":/w -w /w mcr.microsoft.com/dotnet/sdk:8.0 sh -c '
  dotnet build talktome.sln --configuration Release -p:EnableWindowsTargeting=true &&
  dotnet test talktometest --configuration Release --no-build'
