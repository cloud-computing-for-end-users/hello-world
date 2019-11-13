

function StartServer {
    Start-Process cmd.exe -ArgumentList "/C docker run -p 5522:5522 -p 5523:5523 server-module isLocal:false scp:5522 srp:5523"
    Start-Sleep -Seconds 4
}


function StartFileServer{
    Start-Process cmd.exe -ArgumentList "/C docker run file-servermodule isLocal:false rcp:5522 rrp:5523 rip:172.17.0.2"
    #Start-Sleep -Seconds 6
}


function StartDatabaseServer{
    Start-Process cmd.exe -ArgumentList "/C docker run -p 11433:1433 database-servermodule scp:5542 rcp:5522 rrp:5523 isLocal:false rip:172.17.0.2"
    #Start-Sleep -Seconds 6
}


function StartSlaveOwner {
    Start-Process -FilePath cmd.exe -ArgumentList "/C docker run slave-owner scp:5532 srp:5533 rcp:5522 rrp:5523 isLocal:false  rip:172.17.0.2 `"{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':60252},'IP':{'TheIP':'10.152.212.13'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':60253},'ConnectToRecieveImagesPort':{'ThePort':60254}},'ApplicationName':'WordPad','ApplicationVersion':'2','OperatingSystemName':'Windows 10'}`" `"{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':60452},'IP':{'TheIP':'10.152.212.13'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':60453},'ConnectToRecieveImagesPort':{'ThePort':60454}},'ApplicationName':'Paint','ApplicationVersion':'1','OperatingSystemName':'Windows 10'}`""
   # "`"{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':10142},'IP':{'TheIP':'127.0.0.1'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':10143},'ConnectToRecieveImagesPort':{'ThePort':30303}},'ApplicationName':'Paint','ApplicationVersion':'1','OperatingSystemName':'Windows 10'}`"" }
}
StartServer
StartFileServer
StartDatabaseServer
StartSlaveOwner

#Start-Process cmd.exe -ArgumentList "/C docker run slave-owner scp:5532 srp:5533 rcp:5522 rrp:5523 isLocal:false  rip:172.17.0.2 `"{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':60252},'IP':{'TheIP':'10.152.212.20'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':60253},'ConnectToRecieveImagesPort':{'ThePort':60254}},'ApplicationName':'Paint','ApplicationVersion':'2','OperatingSystemName':'Windows 10'}" "{'SlaveConnection':{'ConnectionInformation':{'Port':{'ThePort':60452},'IP':{'TheIP':'10.152.212.20'}},'OwnerPrimaryKey':null,'SlaveID':null,'RegistrationPort':{'ThePort':60453},'ConnectToRecieveImagesPort':{'ThePort':60454}},'ApplicationName':'Paint','ApplicationVersion':'1','OperatingSystemName':'Windows 10'}`""
#Start-Sleep -Seconds 6





