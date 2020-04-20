# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

ARG GOOGLE_CLIENT_ID
ARG GOOGLE_SECRET
ARG ${SQL_SOURCE}
ARG SQL_USER
ARG SQL_PASSWORD

ENV GOOGLE_CLIENT_ID=${GOOGLE_CLIENT_ID}
ENV GOOGLE_SECRET=${GOOGLE_SECRET}
ENV SQL_SOURCE=${SQL_SOURCE}
ENV SQL_USER=${SQL_USER}
ENV SQL_PASSWORD=${SQL_PASSWORD}

ENTRYPOINT ["/bin/bash", "variables.sh"]

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore


# copy everything else and build app
COPY . ./
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 5000
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "Hydra.IdentityServer.dll"]