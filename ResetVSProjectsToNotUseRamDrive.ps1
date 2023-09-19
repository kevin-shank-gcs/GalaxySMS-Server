# Find all project files...
$projectFiles = Get-ChildItem -Filter *.csproj -Recurse 
# Get project directories
$projectDirectories = $projectFiles | ForEach-Object { $_.DirectoryName } | Get-Unique


# Unlink bin-directories to ramdisk
$projectDirectories | ForEach-Object { cmd /c rmdir "$($_)\bin"   }

# Unlink obj-directories to ramdisk
$projectDirectories | ForEach-Object { cmd /c rmdir "$($_)\obj"   }
