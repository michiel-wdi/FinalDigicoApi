# FinalDigicoApi

Enter the connection string into appsettings.json

run command:
#if no migrations are made
- dotnet ef migation add <Name>
- dotnet ef database update

#else
  - dotnet ef database update
  
to revert you do have to drop the table tho
