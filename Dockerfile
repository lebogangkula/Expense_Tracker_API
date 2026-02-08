# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime 
WORKDIR /publish 
COPY ./out . 
ENTRYPOINT ["dotnet", "ExpenseAPI.dll"]
