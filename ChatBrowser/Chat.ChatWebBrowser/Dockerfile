#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Chat.ChatWebBrowser/Chat.ChatWebBrowser.csproj", "Chat.ChatWebBrowser/"]
COPY ["Chat.IoC/Chat.IoC.csproj", "Chat.IoC/"]
COPY ["Chat.Repositories.EFCore/Chat.Repositories.EFCore.csproj", "Chat.Repositories.EFCore/"]
COPY ["Chat.Entities/Chat.Entities.csproj", "Chat.Entities/"]
COPY ["Chat.UseCases/Chat.UseCases.csproj", "Chat.UseCases/"]
COPY ["Chat.UseCasesDTOs/Chat.UseCasesDTOs.csproj", "Chat.UseCasesDTOs/"]
RUN dotnet restore "Chat.ChatWebBrowser/Chat.ChatWebBrowser.csproj"
COPY . .
WORKDIR "/src/Chat.ChatWebBrowser"
RUN dotnet build "Chat.ChatWebBrowser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.ChatWebBrowser.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.ChatWebBrowser.dll"]
