rem ffmpeg -loglevel debug -y -f gdigrab -framerate 5 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1800x1000 -i desktop -frames:v 5 -c copy -vcodec png -f mjpeg -update 1 tcp://127.0.0.1:60607

rem ffmpeg -loglevel debug -y -f gdigrab -framerate 5 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1800x1000 -i desktop -frames:v 5 -vcodec mjpeg -f image2pipe -q:v 31 -update 1 "image.jpg"

rem video local
rem ffmpeg -loglevel debug -y -f gdigrab -framerate 24 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1800x1000 -i desktop -frames:v 5 -vcodec libx264 -f mpegts video.mkv

rem video send 
rem ffmpeg -loglevel debug -y -f gdigrab -framerate 6 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1800x1000 -i desktop -frames:v 1 -vcodec libx264 -f mpegts tcp://127.0.0.1:60607

rem HLS - not finished
rem ffmpeg -loglevel debug -y -f gdigrab -framerate 6 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1800x1000 -i desktop -frames:v 6 -c:v libx264 -r 6 -hls_list_size 6 exp.m3u8

rem HTTP
rem ffmpeg -loglevel debug -y -f gdigrab -framerate 6 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1000x750 -i desktop -preset veryfast -c:v libx264 -f mpegts http://127.0.0.1:60607/desktop.mkv

rem -tune zerolatency 

rem Video to PNGs
rem ffmpeg -loglevel debug -y -i video.mkv "img%03d.png"

rem using VLC HTTP OGG
rem "C:\Program Files (x86)\VideoLAN\VLC\vlc.exe" -I dummy screen:// :screen-fps=16.000000 :screen-caching=100 :sout=#transcode{vcodec=theo,vb=800,scale=1,width=600,height=480,acodec=mp3}:http{mux=ogg,dst=127.0.0.1:60607/desktop.ogg} :no-sout-rtp-sap :no-sout-standard-sap :ttl=1 :sout-keep

rem "C:\Program Files (x86)\VideoLAN\VLC\vlc.exe" -I dummy screen:// :screen-fps=16.000000 :screen-caching=100 :sout=#transcode{vcodec=theo,vb=512,scale=1,acodec=none}:http{mux=ogg,dst=127.0.0.1:60607/stream.ogg} :no-sout-rtp-sap :no-sout-standard-sap :sout-keep

rem "C:\Program Files (x86)\VideoLAN\VLC\vlc.exe" -I dummy screen:// :screen-fps=16.000000 :screen-caching=100 :sout="#transcode{vcodec=h264,vb=500, venc=x264{aud,profile=baseline,level=30,keyint=30,ref=1}, aenc=none} :std{access=livehttp{seglen=10,delsegs=true,numsegs=5, index=C:\wamp\www\stream.m3u8, index-url=http://_ip_addr_of_your_web_server/stream-########.ts}, mux=ts{use-key-frames}, dst=C:\wamp\www\stream-########.ts}"





rem Unreal - my first try
rem ffmpeg -loglevel debug -y -f gdigrab -framerate 6 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 1000x750 -i desktop -preset veryfast -c:v libx264 -f mpegts rtmp://127.0.0.1:5130/live/mytest/livestream

ffmpeg -loglevel debug -y -f gdigrab -framerate 30 -offset_x 0 -offset_y 0 -draw_mouse 0 -s 640x360 -i desktop -preset veryfast -c:v libx264 -bf 0 -b:v 1500k -x264-params keyint=30:rc_lookahead=1 -f flv rtmp://127.0.0.1:5130/live/mytest/livestream

pause