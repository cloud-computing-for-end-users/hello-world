function BuildDocker {
    param ([string]$moduleName)
    switch($moduleName) {
        'server' { StartBuild -path 'server-module' -args 'server'}
        'slave-owner' { StartBuild -path 'slave-owner-servermodule' -args 'slave-owner' }
        'database' { StartBuild -path 'database-servermodule' -args 'database-servermodule' }
        'file' { StartBuild -path 'file-servermodule' -args 'file-servermodule' }
    }
}

function StartBuild {
    param(
        [Parameter(Mandatory=$true)][string]$path,
        [Parameter(Mandatory=$false)][string]$args
    )
    cd $PSScriptRoot\..\..\$path
    docker build -t $args .
    #Start-Process cmd.exe -ArgumentList "/C docker build -t $args $path"
    #Start-Sleep -Seconds 6
}

BuildDocker('server')
BuildDocker('file')
BuildDocker('slave-owner')
BuildDocker('database')