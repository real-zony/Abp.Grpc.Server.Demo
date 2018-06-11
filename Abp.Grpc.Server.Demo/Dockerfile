FROM microsoft/dotnet
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
EXPOSE 5001

WORKDIR /app
COPY ./ .

ENTRYPOINT [ "dotnet","Abp.Grpc.Server.Demo.dll" ]