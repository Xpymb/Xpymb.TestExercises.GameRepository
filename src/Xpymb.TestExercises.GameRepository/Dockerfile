FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Xpymb.TestExercises.ASP.GameRepository/Xpymb.TestExercises.ASP.GameRepository.csproj", "Xpymb.TestExercises.ASP.GameRepository/"]
RUN dotnet restore "Xpymb.TestExercises.ASP.GameRepository/Xpymb.TestExercises.ASP.GameRepository.csproj"
COPY . .
WORKDIR "/src/Xpymb.TestExercises.ASP.GameRepository"
RUN dotnet build "Xpymb.TestExercises.ASP.GameRepository.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xpymb.TestExercises.ASP.GameRepository.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xpymb.TestExercises.ASP.GameRepository.dll"]
