function StartModule {
    param ([string]$moduleName)
    switch($moduleName) {
        'server' { StartAndSleep -path 'server-module\src\server-module' }
        'slave-owner' { StartAndSleep -path 'slave-owner-servermodule\src\slave-owner-servermodule' -args "`"{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':10142},'IP':{'TheIP':'127.0.0.1'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':10143},'ConnectToRecieveImagesPort':{'ThePort':30303}},'ApplicationName':'Paint','ApplicationVersion':'1','OperatingSystemName':'Windows 10'}`"" }
        'slave' { StartAndSleep -path 'slave-module\src\slave-controller' }
        'database' { StartAndSleep -path 'database-servermodule\src\database-servermodule' }
        'file' { StartAndSleep -path 'file-servermodule\src\file-servermodule' }
    }
}

function StartAndSleep {
    param(
        [Parameter(Mandatory=$true)][string]$path,
        [Parameter(Mandatory=$false)][string]$args
    )
    cd $PSScriptRoot\..\$path
    Start-Process cmd.exe -ArgumentList "/C dotnet run $args && pause"
    Start-Sleep -Seconds 6
}

StartModule('server')
StartModule('file')
StartModule('slave-owner')
StartModule('slave')
#StartModule('database')
