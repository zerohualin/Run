dotnet restore
dotnet publish -r linux-x64 --no-self-contained --no-dependencies -c Release

path="./Publish/linux-x64"
rm -rf "$path/Bin"
cp -r ./Bin/linux-x64/publish "$path/Bin"

rm -rf "$path/Config"
cp -r ./Config "$path/Config"