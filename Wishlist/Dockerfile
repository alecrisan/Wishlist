#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
RUN curl -sL https://deb.nodesource.com/setup_17.x |  bash -
RUN apt-get install -y nodejs

COPY ["Wishlist.csproj", "./"]
RUN dotnet restore "Wishlist.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Wishlist.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wishlist.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wishlist.dll"]
