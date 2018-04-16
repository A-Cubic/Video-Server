FROM microsoft/dotnet
WORKDIR /app
EXPOSE 80
ADD obj/Docker/publish /app
RUN cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
ENTRYPOINT ["dotnet", "Video-Server.dll"]