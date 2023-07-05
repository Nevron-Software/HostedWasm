#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# get ASP.NET:6.0 (the actual os) and name it build

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

#set working directory
WORKDIR /app
# expose ports 80 and 443
EXPOSE 80
EXPOSE 443
# get sdk:6.0 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

#set working directory to src
WORKDIR /src
#copy the project files
COPY ["Server/HostedWasm.Server.csproj", "Server/"]
COPY ["Client/HostedWasm.Client.csproj", "Client/"]
COPY ["Shared/HostedWasm.Shared.csproj", "Shared/"]
# run dot.net restore
RUN dotnet restore "Server/HostedWasm.Server.csproj"
# copy current folder to the working folder into the container
COPY . .
#set the working directory to src/server
WORKDIR "/src/Server"
# run dot.net build in release mode
RUN dotnet build "HostedWasm.Server.csproj" -c Release -o /app/build
# publish
FROM build AS publish
RUN dotnet publish "HostedWasm.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false
# copy the folder with the published project in /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostedWasm.Server.dll"]