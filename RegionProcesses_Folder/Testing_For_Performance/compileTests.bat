@echo off
setlocal enabledelayedexpansion

set "files=Africa.cs Asia.cs Europe.cs NorthAmerica.cs Oceania.cs SouthAmerica.cs RegionControl.cs"

for %%f in (%files%) do (
    echo Compiling "%%f"...
    csc "%%f"
    if errorlevel 1 (
        echo Failed to compile "%%f".
        exit /b 1
    )
)

echo All files compiled successfully.
exit /b 0
