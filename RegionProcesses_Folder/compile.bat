@echo off
setlocal enabledelayedexpansion

set "files=PipeAfrica.cs PipeAsia.cs PipeEurope.cs PipeNorthAmerica.cs PipeOceania.cs PipeSouthAmerica.cs PipeRegionControl.cs"

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
