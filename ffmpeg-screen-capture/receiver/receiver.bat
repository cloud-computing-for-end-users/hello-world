rem ffmpeg -y -i tcp://127.0.0.1:60607?listen -update 1 -c copy received.png

rem ffmpeg -y -i tcp://127.0.0.1:60607?listen -update 1 -c copy video.mkv

rem ffmpeg -y -i tcp://127.0.0.1:60607?listen -update 1 video.png

ffmpeg -y -listen 1 -i http://127.0.0.1:60607 -update 1 somefile.png

rem ffmpeg -loglevel debug -y -i video.mkv img.png

pause