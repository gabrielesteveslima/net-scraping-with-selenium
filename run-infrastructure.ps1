Set-Location -Path "src/service/sib-sample-infrastructure"

dotnet tool restore;
dotnet ef migrations add UpInitalSchemaTables -o \Design\Migrations;
dotnet ef database update;