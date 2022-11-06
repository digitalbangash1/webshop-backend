#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src


COPY webshop-backend.csproj .
RUN dotnet restore


COPY . .

RUN dotnet build  -c Release
RUN dotnet test 
RUN dotnet publish -c Release -o /dist



FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_ENVIROMENT production
ENV ASPNETCORE_URLs http://+:80
EXPOSE 80

WORKDIR /app
COPY --from=build /dist .
CMD ["dotnet", "webshop-backend.dll"]
