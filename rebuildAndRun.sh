# 1. Clear ALL NuGet caches
dotnet nuget locals all --clear

# 2. Delete bin/obj in BOTH projects
cd ~/Desktop/Projects/Cruddy/Cruddy/Cruddy.Core
rm -rf bin obj

cd ~/Desktop/Projects/Cruddy/TestCruddy/CruddyTest/CruddyTest.Api
rm -rf bin obj

# 3. Bump version in Cruddy.Core.csproj
# Change Version from 1.1.2 to 1.1.3

# 4. Pack with new version
cd ~/Desktop/Projects/Cruddy/Cruddy/Cruddy.Core
dotnet pack -c Release

# 5. Update package reference
cd ~/Desktop/Projects/Cruddy/TestCruddy/CruddyTest/CruddyTest.Core
dotnet remove package Cruddy.Core
dotnet add package Cruddy.Core --source ~/Desktop/Projects/Cruddy/Cruddy/Cruddy.Core/bin/Release --version 1.1.3

cd ~/Desktop/Projects/Cruddy/TestCruddy/CruddyTest/CruddyTest.Api

# 6. Run
dotnet run