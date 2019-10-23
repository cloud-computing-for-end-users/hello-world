function StartModule {
    param ([string]$moduleName)
    switch($moduleName) {
        'server' { StartAndSleep('server-module\src\server-module') }
        'slave-owner' { StartAndSleep('slave-owner-servermodule\src\slave-owner-servermodule') }
        'slave' { StartAndSleep('slave-module\src\slave-controller') }
        'database' { StartAndSleep('database-servermodule\src\database-servermodule') }
    }
}

function StartAndSleep($path) {
    cd $PSScriptRoot\..\$path
    Start-Process cmd.exe -ArgumentList "/C dotnet run && pause"
    Start-Sleep -Seconds 10
}

StartModule('server')
StartModule('slave-owner')
#StartModule('slave')
StartModule('database')
