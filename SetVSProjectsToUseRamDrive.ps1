$ramDiskDrive = "E:"

# Find all project files...
$projectFiles = Get-ChildItem -Filter *.csproj -Recurse 
# Get project directories
$projectDirectories = $projectFiles | ForEach-Object { $_.DirectoryName } | Get-Unique


# Create a bin-directory on the RAM-drive
$projectDirectories | ForEach-Object { New-Item -ItemType Directory -Force -Path "$ramDiskDrive$($_.Substring(2))\bin" } 

# Remove existing bin-directories
$projectDirectories | ForEach-Object { Remove-Item "$($_)\bin" -Force -Recurse }

# Link bin-directories to ramdisk
$projectDirectories | ForEach-Object { cmd /c mklink /D "$($_)\bin" "$ramDiskDrive$($_.Substring(2))\bin" }


# Create a obj-directory on the RAM-drive
$projectDirectories | ForEach-Object { New-Item -ItemType Directory -Force -Path "$ramDiskDrive$($_.Substring(2))\obj" } 

# Remove existing obj-directories
$projectDirectories | ForEach-Object { Remove-Item "$($_)\obj" -Force -Recurse }

# Link obj-directories to ramdisk
$projectDirectories | ForEach-Object { cmd /c mklink /D "$($_)\obj" "$ramDiskDrive$($_.Substring(2))\obj" }
