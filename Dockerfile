FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./CFP.Api/CFP.Api.csproj"
COPY . .
WORKDIR "/src/CFP.Api"
RUN dotnet build "CFP.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CFP.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CFP.Api.dll"]