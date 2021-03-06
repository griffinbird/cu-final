FROM microsoft/dotnet:2.1-sdk AS builder
WORKDIR /app



# caches restore result by copying csproj file separately
COPY *.csproj .
RUN dotnet restore

#r44t
COPY . .
RUN dotnet publish --output /app/ --configuration Release
RUN sed -n 's:.*<AssemblyName>\(.*\)</AssemblyName>.*:\1:p' *.csproj > __assemblyname
RUN if [ ! -s __assemblyname ]; then filename=$(ls *.csproj); echo ${filename%.*} > __assemblyname; fi



# Stage 2
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=builder /app .

#ENV PORT 7616
#EXPOSE 7616

ENTRYPOINT dotnet $(cat /app/__assemblyname).dll