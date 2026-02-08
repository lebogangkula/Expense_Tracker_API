# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Expense_Tracker_API/ExpenseAPI.csproj"
RUN dotnet publish "Expense_Tracker_API/ExpenseAPI.csproj" -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /publish
COPY --from=build /out .
ENTRYPOINT ["dotnet", "ExpenseAPI.dll"]
