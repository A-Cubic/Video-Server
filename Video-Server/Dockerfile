FROM microsoft/dotnet
WORKDIR /app
EXPOSE 80
COPY obj/Docker/publish /app
ENTRYPOINT ["dotnet", "Video-Server.dll"]