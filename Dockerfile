# Defines image for build environment
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS BUILD

# Defines work directory
WORKDIR /build

# Copy all project folder items
COPY . .

# Restore and Publish
RUN dotnet publish Poc.Net.Mongo.Api -r linux-musl-x64 -p:PublishReadyToRun --self-contained -c Release -o out

# Select image for RUNTIME environment
FROM alpine:3.20 AS RUNTIME

# Install required dependencies
RUN apk upgrade --no-cache &&\
apk add --no-cache libgcc libstdc++ icu-libs

# Defines app work directory
WORKDIR /app

# Copy builded app to his destination
COPY --from=BUILD /build/out .

# Defines globalization invariant to FALSE
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Exposes port
EXPOSE 8080

# Defines ASP .NET Core App Port
ENV ASPNETCORE_URLS=http://*:8080

# Create entrypoint file
RUN echo "./Poc.Net.Mongo.Api" >> entrypoint.sh &&\
chmod u+x entrypoint.sh

# Defines entrypoint
ENTRYPOINT ["sh", "entrypoint.sh"]