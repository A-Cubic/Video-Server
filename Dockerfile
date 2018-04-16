FROM microsoft/dotnet
WORKDIR /app
EXPOSE 80
ADD /home/travis/build/A-Cubic/Video-Server/Video-Server/obj/Docker/publish /app
RUN cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
ENTRYPOINT ["dotnet", "Video-Server.dll"]