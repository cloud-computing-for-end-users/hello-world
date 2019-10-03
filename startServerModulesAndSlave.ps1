
$RunServerModules = $True # $False

if($RunServerModules) {
    # server module
    cd $PSScriptRoot\..\server-module\src\server-module\server-module
    Start-Process cmd.exe -ArgumentList "/C dotnet run && pause"
    Start-Sleep -Seconds 7

    # slave owner servermodule
    cd $PSScriptRoot\..\slave-owner-servermodule\src\slave-owner-servermodule\slave-owner-servermodule
    Start-Process cmd.exe -ArgumentList "/C dotnet run && pause"
    Start-Sleep -Seconds 7
}
# slave module
cd $PSScriptRoot\..\slave-module\src\slave-controller
Start-Process cmd.exe -ArgumentList "/C dotnet run && pause"
