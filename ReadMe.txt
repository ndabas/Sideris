Quick overview:

Sideris        - the peer-to-peer app itself.
SiderisGalaxy  - the peer discovery server.
SiderisServer  - HTTP server component common to Sideris and SiderisGalaxy.
SiderisStellar - ASP.NET web service to keep track of peers and shared files.


How to run:

Build the solution. Start SiderisGalaxy, and click the start button. It will
take a few seconds to start.

Now start Sideris on the peer computers. In the options dialog, you must enter
the name (or IP address) of the Galaxy server and the port it is started on.
You can use a hostname (like yoda:13060) or IP (like 192.168.100.1:13060.)

You should also select a folder to share and a folder to receive incoming
files in the options dialog.

Click connect from the connection menu in Sideris and it should connect in a
few seconds. When multiple clients are connected, you can use the search
function to find files others have shared and download them.

If it doesn't connect, see that you have the correct name/IP and port, your
firewall is set up to allow Sideris, etc.

For testing, you can start Galaxy and two (or more) instances of Sideris on
the same computer: Start Galaxy; then start the first instance of Sideris.
Connect this instance. Then start another instance. Change the incoming port
in this instance. Now connect this one as well.