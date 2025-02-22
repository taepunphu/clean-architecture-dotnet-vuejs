build: 
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project src/presentation/Travel.WebApi/Travel.WebApi.csproj
run:
	dotnet run --project src/presentation/Travel.WebApi/Travel.WebApi.csproj