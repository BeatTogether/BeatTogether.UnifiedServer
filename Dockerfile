# Stage 1: Build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy everything from the host machine into the container
COPY . .

RUN dotnet clean BeatTogether.UnifiedServer.sln -c Release

# Build for linux x64 for now (no multiarch support yet)
RUN dotnet publish BeatTogether.UnifiedServer.sln -c Release -p:PublishReadyToRun=true -p:PublishTrimmed=false -p:TargetFramework=net6.0 -r linux-x64 -o /tmp/out

# Stage 2: Create a new runtime container
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime

WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /tmp/out /app

ENTRYPOINT ["/app/BeatTogether.UnifiedServer"]
