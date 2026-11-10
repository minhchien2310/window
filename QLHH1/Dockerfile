FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QLHH1.csproj", "./"]
RUN dotnet restore "QLHH1.csproj"
COPY . .
RUN dotnet build "QLHH1.csproj" -c Release -o /app/build /p:BuildInParallel=false /p:UseSharedCompilation=false

FROM build AS publish
RUN dotnet publish "QLHH1.csproj" -c Release -o /app/publish /p:UseAppHost=false /p:BuildInParallel=false /p:UseSharedCompilation=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QLHH1.dll"]