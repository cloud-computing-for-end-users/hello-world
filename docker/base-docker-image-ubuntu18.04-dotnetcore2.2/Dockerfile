# Dockerfile for base ubuntu image, that among other tools installs .net core
FROM ubuntu:18.04 as base

# start nessesary for install of dot net core 2.2
RUN apt update
RUN apt install wget -y	
RUN apt upgrade -y
RUN apt install software-properties-common -y

#https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/runtime-2.2.0
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
# end nessesary for install of dot net core 2.2

#installing .Net Core 2.2
RUN add-apt-repository universe
RUN apt-get update
RUN apt-get install apt-transport-https -y
RUN apt-get update
RUN apt-get install aspnetcore-runtime-2.2=2.2.0-1 -y



#installing vim for ease of debugging in interactive mode
RUN apt install vim -y

#install ip command simular to ifconfig but better
RUN apt install iproute2 -y

#installing ping command
RUN apt install iputils-ping -y
