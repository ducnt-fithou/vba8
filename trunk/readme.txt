To build the Windows Phone projects, you need to install the Windows Live SDK first (SkyDrive API):
http://msdn.microsoft.com/en-us/library/live/hh826550.aspx

To make the SkyDrive API work, you need to add your own Client ID in the file MainPage.xaml in the following part (replace <CLIENT ID>):

<Controls:SignInButton Content="SignInButton" Name="signinButton"
                                ClientId="<CLIENT ID>"
                                Branding="Skydrive"
                                Scopes="wl.signin wl.skydrive_update wl.offline_access"
                                SessionChanged="btnSignin_SessionChanged" Width="200" Height="72" VerticalAlignment="Top"/>

You can acquire your own client id at https://account.live.com/developers/applications/create

VBA8 / VGBC8 currently are in one project, but seperated by a compiler switch ("GBC") and some manually exchanged strings. 
Sadly I didn't have the time to properly seperate them or integrate them into one app without having a lot of bugs when switching from a GBA to GBC game (that's the reason there exist 2 apps). 
I also couldn't manage to spare some time for some necessary refactoring (you will see it!). 