FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80

COPY ["../Dotnet.Homeworks.MainProject/Dotnet.Homeworks.MainProject.csproj", "Dotnet.Homeworks.MainProject/"]
COPY ["../Dotnet.Homeworks.Data/Dotnet.Homeworks.Data.csproj", "Dotnet.Homeworks.Data/"]
COPY ["../Dotnet.Homeworks.DataAccess/Dotnet.Homeworks.DataAccess.csproj", "Dotnet.Homeworks.DataAccess/"]
COPY ["../Dotnet.Homeworks.Features/Dotnet.Homeworks.Features.csproj", "Dotnet.Homeworks.Features/"]
COPY ["../Dotnet.Homeworks.Infrastructure/Dotnet.Homeworks.Infrastructure.csproj", "Dotnet.Homeworks.Infrastructure/"]
COPY ["../Dotnet.Homeworks.Domain/Dotnet.Homeworks.Domain.csproj", "Dotnet.Homeworks.Domain/"]
COPY ["../Dotnet.Homeworks.Mediator/Dotnet.Homeworks.Mediator.csproj", "Dotnet.Homeworks.Mediator/"]
COPY ["../Dotnet.Homeworks.Shared/Dotnet.Homeworks.Shared.csproj", "Dotnet.Homeworks.Shared/"]
COPY ["../Dotnet.Homeworks.Storage.API/Dotnet.Homeworks.Storage.API.csproj", "Dotnet.Homeworks.Storage.API/"]
COPY ["../Dotnet.Homeworks.Mailing.API/Dotnet.Homeworks.Mailing.API.csproj", "Dotnet.Homeworks.Mailing.API/"]

RUN dotnet restore "Dotnet.Homeworks.MainProject/Dotnet.Homeworks.MainProject.csproj"

COPY ../ .
WORKDIR "/app/Dotnet.Homeworks.MainProject"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.Homeworks.MainProject.dll"]