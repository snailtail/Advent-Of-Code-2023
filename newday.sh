#!/bin/sh

git checkout main
git pull -r
git checkout -b day$1

# Get the data for this day, and generate a file for testinput
python3 ./getinput.py $1
touch ./data/$1test.dat

# Create the project and a unit test
dotnet new console -o $1
dotnet new xunit -o $1-test

# Add to the solution
dotnet sln add $1/$1.csproj
dotnet sln add $1-test/$1-test.csproj

# Go down into the test project and add shouldly and a reference to the days project
cd $1-test
dotnet add package shouldly
dotnet add reference ../$1/$1.csproj
dotnet add reference ../common/common.csproj
cd ..

# Go down into the days project and add reference to the common classlib
cd $1
dotnet add reference ../common/common.csproj
cd ..


echo "# :christmas_tree: Advent of Code 2023 Day$1 :christmas_tree:" > $1.md
git add .
git commit -m "Add new day $1"
git push --set-upstream origin day$1