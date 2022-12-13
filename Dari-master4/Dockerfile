FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /

# copy csproj and restore as distinct layers
COPY *.sln .
COPY /*.csproj ./aspnetapp/


# copy everything else and build app
COPY /. ./aspnetapp/
WORKDIR /source/aspnetapp


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /
COPY --from=build / ./
ENTRYPOINT ["", ""]