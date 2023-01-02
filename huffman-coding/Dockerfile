#Build Stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
COPY /teste .
RUN dotnet restore "./huffman-coding.csproj" --disable-parallel
RUN dotnet publish "./huffman-coding.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
COPY /teste .
COPY --from=build /app ./
EXPOSE 5000

ENTRYPOINT ["dotnet", "huffman-coding.dll"]