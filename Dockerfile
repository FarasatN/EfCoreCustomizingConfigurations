#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
#USER app
#WORKDIR /app
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["EfCoreCustomizingConfigurations.csproj", "."]
#RUN dotnet restore "./EfCoreCustomizingConfigurations.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "./EfCoreCustomizingConfigurations.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./EfCoreCustomizingConfigurations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "EfCoreCustomizingConfigurations.dll"]


#FROM mcr.microsoft.com/mssql/server:latest
#
#ENV SA_PASSWORD=fn230196nf
#ENV ACCEPT_EULA=Y
#
#EXPOSE 1439

#-------------------------------------------------------------------
#quick way

#docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=87654321Fn@' -e 'MSSQL_PID_Express' -p 1439:1433 --name mssql --hostname mssql -d mcr.microsoft.com/mssql/server:2022-latest
#Server=localhost,1439;Database=mssql;User=sa;Password=87654321F@;
#Server=localhost,1439;Initial Catalog=mssql;Integrated Security=True;User Id=sa;Password=87654321Fn@;
#docker start mssql
#docker stop mssql

#backup data- if you remove container, data is gone with it
#docker rm -f sql

#to keep data:
#docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1439:1433 -d --name=sql -v //c/mount/sql:/var/opt/mssql/data mcr.microsoft.com/mssql/server:latest
 