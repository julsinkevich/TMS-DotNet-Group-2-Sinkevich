#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/RecipesFinder_bot/RecipesFinder_bot.csproj", "src/RecipesFinder_bot/"]
RUN dotnet restore "src/RecipesFinder_bot/RecipesFinder_bot.csproj"
COPY . .
WORKDIR "/src/src/RecipesFinder_bot"
RUN dotnet build "RecipesFinder_bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecipesFinder_bot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet RecipesFinder_bot.dll